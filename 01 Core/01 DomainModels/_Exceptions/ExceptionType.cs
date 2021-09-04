using Store.DomainModels.Properties;

namespace Store.DomainModels._Exceptions
{
    public enum ExceptionType
    {
        InitializeDataBaseException = -102,
        DataAccessException = -101,

        InvalidValueObjectStateException = 101,
        ProductNotFoundException = 102,
        ProductOptionNotFoundException = 103,
        ProductNameDuplicateException = 104,
    }

    public static class ExceptionTypeExtension
    {
        public static int Code(this ExceptionType type) => (int)type;

        public static string Message(this ExceptionType type)
            => Resources.ResourceManager.GetString(type.ToString()) ?? type.ToString();
    }
}