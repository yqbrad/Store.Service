using System;

namespace Store.DomainModels._Exceptions
{
    [Serializable]
    public abstract class BaseException : Exception
    {
        public abstract int ExCode { get; }
        public abstract string ExMessage { get; }

        public BaseException() : base() => HResult = ExCode;

        public BaseException(Exception innerException)
            : base(string.Empty, innerException) => HResult = ExCode;

        public override string Message => ExMessage;
    }
}