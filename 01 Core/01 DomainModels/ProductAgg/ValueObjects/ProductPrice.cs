using Framework.Domain.BaseModels;
using Store.DomainModels._Exceptions;

namespace Store.DomainModels.ProductAgg.ValueObjects
{
    public class ProductPrice : BaseValueObject<ProductPrice>
    {
        public decimal Value { get; private set; }

        public ProductPrice(decimal value)
        {
            if (value < 0)
                throw new InvalidValueObjectStateException("قیمت محصول باید بیشتر از صفر ریال باشد");

            Value = value;
        }

        public override bool ObjectIsEqual(ProductPrice otherObject)
            => otherObject.Value == Value;

        public override int ObjectGetHashCode()
            => Value.GetHashCode();

        public static implicit operator decimal(ProductPrice price) => price.Value;
    }
}