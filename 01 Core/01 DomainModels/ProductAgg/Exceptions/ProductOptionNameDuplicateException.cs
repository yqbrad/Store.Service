using Store.DomainModels._Exceptions;

namespace Store.DomainModels.ProductAgg.Exceptions
{
    public class ProductOptionNameDuplicateException : BaseException
    {
        public override int ExCode => ExceptionType.ProductOptionNameDuplicateException.Code();
        public override string ExMessage => ExceptionType.ProductOptionNameDuplicateException.Message();
    }
}