using System;

namespace Store.DomainModels._Exceptions
{
    public class DataAccessException : BaseException
    {
        public DataAccessException(Exception innerException) : base(innerException) { }

        public override int ExCode => ExceptionType.DataAccessException.Code();
        public override string ExMessage => ExceptionType.DataAccessException.Message();
    }
}