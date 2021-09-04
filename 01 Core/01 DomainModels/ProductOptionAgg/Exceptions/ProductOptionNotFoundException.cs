using Store.DomainModels._Exceptions;

namespace Store.DomainModels.ProductOptionAgg.Exceptions
{
    public class ProductOptionNotFoundException : BaseException
    {
        public override int ExCode => ExceptionType.ProductOptionNotFoundException.Code();
        public override string ExMessage => ExceptionType.ProductOptionNotFoundException.Message();
    }
}