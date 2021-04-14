using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Domain.Responses
{
    public class BaseResponse<T> where T : class
    {
        public T context { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        public BaseResponse(T context)
        {
            this.Success = true;
            this.context = context;
        }
        public BaseResponse(string message)
        {
            this.Success = false;
            this.Message = message;
        }
    }
}