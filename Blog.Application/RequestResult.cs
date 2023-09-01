using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application
{
    public class RequestResult<T> where T : class
    {
        public string Message { get; private set; }
        public bool Success { get; private set; }
        public T Data { get; private set; }

        public RequestResult(string message, bool success, T data = default(T))
        {
            Message = message;
            Success = success;
            Data = data;
        }
    }
}
