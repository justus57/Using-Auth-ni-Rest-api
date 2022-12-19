﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiUpdate
{
    public class HttpException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public HttpException(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
        }

        public HttpException(int httpStatusCode)
            : this((HttpStatusCode)httpStatusCode)
        {
        }

        public HttpException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            this.StatusCode = statusCode;
        }

        public HttpException(int httpStatusCode, string message)
            : this((HttpStatusCode)httpStatusCode, message)
        {
        }

        public HttpException(HttpStatusCode statusCode, string message, Exception inner)
            : base(message, inner)
        {
        }

        public HttpException(int httpStatusCode, string message, Exception inner)
            : this((HttpStatusCode)httpStatusCode, message, inner)
        {
        }
    }
}
