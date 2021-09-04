using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Store.ApplicationServices.ProductAgg.Request;
using Store.DomainModels.ProductAgg.Dtoes;
using Store.DomainModels.ProductAgg.Requests;
using Store.Infrastructure.Service.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Store.EndPoints.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly ICacheProvider _cacheProvider;
        private readonly DistributedCacheEntryOptions _cacheOptions;
        public ProductsController(ICacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
            _cacheOptions = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddMinutes(Config.CacheDuration))
                .SetSlidingExpiration(TimeSpan.FromMinutes(2));
        }

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ProductDetails>), 200)]
        public Task<IActionResult> GetAll(
            [FromServices] GetAllProductHandlerAsync service)
            => HandleAsync(service.HandleAsync);

        /// <summary>
        /// Finds all products matching the specified name.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="name">ProductName</param>
        /// <returns></returns>
        [HttpGet("{name}")]
        [ProducesResponseType(typeof(List<ProductDetails>), 200)]
        public Task<IActionResult> Search(
            [FromServices] SearchProductsHandlerAsync service,
            [FromRoute, Required] string name)
            => HandleAsync(service.HandleAsync, new SearchProducts(name));

        /// <summary>
        /// Gets the product that matches the specified Id.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="id">ProductId</param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ProductDetails), 200)]
        public async Task<IActionResult> Get(
            [FromServices] GetProductHandlerAsync service,
            [FromRoute, Required] Guid id)
        {
            var result = await _cacheProvider.GetFromCache<ProductDetails>(id.ToString());
            if (result is not null)
                return new OkObjectResult(result);

            result = await service.HandleAsync(new GetProduct(id));
            await _cacheProvider.SetCache(id.ToString(), result, _cacheOptions);

            return new OkObjectResult(result);
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<IActionResult> CreateProduct(
            [FromServices] CreateProductHandlerAsync service,
            [FromBody, Required] CreateProduct req)
            => HandleAsync(service.HandleAsync, req);

        /// <summary>
        /// Updates a product
        /// </summary>
        /// <param name="service"></param>
        /// <param name="id">ProductId</param>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            [FromServices] UpdateProductHandlerAsync service,
            [FromRoute, Required] Guid id,
            [FromBody, Required] UpdateProduct req)
        {
            await _cacheProvider.ClearCache(id.ToString());
            req.SetId(id);
            return await HandleAsync(service.HandleAsync, req);
        }

        /// <summary>
        /// Deletes a product and options.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="id">ProductId</param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(
            [FromServices] DeleteProductHandlerAsync service,
            [FromRoute, Required] Guid id)
        {
            await _cacheProvider.ClearCache(id.ToString());
            return await HandleAsync(service.HandleAsync, new DeleteProduct(id));
        }

        /// <summary>
        /// Finds all options for a specified product.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="id">ProductId</param>
        /// <returns></returns>
        [HttpGet("{id:guid}/options")]
        [ProducesResponseType(typeof(List<ProductOptionDetails>), 200)]
        public Task<IActionResult> GetOptions(
            [FromServices] GetAllProductOptionsHandlerAsync service,
            [FromRoute, Required] Guid id)
            => HandleAsync(service.HandleAsync, new GetAllProductOptions(id));

        /// <summary>
        /// Finds the specified product option for the specified product.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="id">ProductId</param>
        /// <param name="optionId">ProductOptionId</param>
        /// <returns></returns>
        [HttpGet("{id:guid}/options/{optionId:guid}")]
        [ProducesResponseType(typeof(ProductOptionDetails), 200)]
        public Task<IActionResult> GetOption(
            [FromServices] GetProductOptionHandlerAsync service,
            [FromRoute, Required] Guid id,
            [FromRoute, Required] Guid optionId)
            => HandleAsync(service.HandleAsync, new GetProductOption(id, optionId));

        /// <summary>
        /// Adds a new product option to the specified product.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="req"></param>
        /// <param name="id">ProductId</param>
        /// <returns></returns>
        [HttpPost("{id:guid}/options")]
        public Task<IActionResult> CreateOption(
            [FromServices] AddProductOptionHandlerAsync service,
            [FromBody, Required] AddProductOption req,
            [FromRoute, Required] Guid id)
        {
            req.SetProductId(id);
            return HandleAsync(service.HandleAsync, req);
        }

        /// <summary>
        /// Updates the specified product option.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="id">ProductId</param>
        /// <param name="req"></param>
        /// <param name="optionId">ProductOptionId</param>
        /// <returns></returns>
        [HttpPut("{id:guid}/options/{optionId:guid}")]
        public Task<IActionResult> UpdateOption(
            [FromServices] UpdateProductOptionHandlerAsync service,
            [FromRoute, Required] Guid id,
            [FromBody, Required] UpdateProductOption req,
            [FromRoute, Required] Guid optionId)
        {
            req.SetProductId(id);
            req.SetOptionId(optionId);
            return HandleAsync(service.HandleAsync, req);
        }

        /// <summary>
        /// Deletes the specified product option.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="id">ProductId</param>
        /// <param name="optionId">ProductOptionId</param>
        /// <returns></returns>
        [HttpDelete("{id:guid}/options/{optionId:guid}")]
        public Task<IActionResult> DeleteOption(
            [FromServices] DeleteProductOptionHandlerAsync service,
            [FromRoute, Required] Guid id,
            [FromRoute, Required] Guid optionId)
            => HandleAsync(service.HandleAsync, new DeleteProductOption(id, optionId));
    }
}