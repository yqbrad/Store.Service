using Store.DomainModels._Exceptions;

namespace Store.DomainModels.ProductAgg.Exceptions
{
    public class ProductNameDuplicateException : BaseException
    {
        public override int ExCode => ExceptionType.ProductNameDuplicateException.Code();
        public override string ExMessage => ExceptionType.ProductNameDuplicateException.Message();
    }
}