using System;

namespace Store.DomainModels._Exceptions
{
    public class InitializeDataBaseException : BaseException
    {
        public InitializeDataBaseException(Exception innerException) : base(innerException) { }

        public override int ExCode => ExceptionType.InitializeDataBaseException.Code();
        public override string ExMessage => ExceptionType.InitializeDataBaseException.Message();
    }
}