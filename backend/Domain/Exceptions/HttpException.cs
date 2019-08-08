using System;

namespace Domain.Exceptions
{
    public class HttpException : Exception
    {
        public int StatusCode { get; private set; }

        public HttpException(int statusCode, string message) : base(message)
        {
            this.StatusCode = statusCode;
        }
    }
}