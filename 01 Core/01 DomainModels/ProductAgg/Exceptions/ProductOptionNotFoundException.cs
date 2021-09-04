using Store.DomainModels._Exceptions;

namespace Store.DomainModels.ProductAgg.Exceptions
{
    public class ProductOptionNotFoundException : BaseException
    {
        public override int ExCode => ExceptionType.ProductOptionNotFoundException.Code();
        public override string ExMessage => ExceptionType.ProductOptionNotFoundException.Message();
    }
}