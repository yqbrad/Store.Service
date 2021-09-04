using Store.DomainModels._Exceptions;

namespace Store.DomainModels.ProductAgg.Exceptions
{
    public class ProductNotFoundException : BaseException
    {
        public override int ExCode => ExceptionType.ProductNotFoundException.Code();
        public override string ExMessage => ExceptionType.ProductNotFoundException.Message();
    }
}