using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication.Domain.Model
{
    public class BaseApiResponse
    {
        public BaseApiResponse()
        {
        }

        public BaseApiResponse(string message, bool success)
        {
            this.Message = message;
            this.Success = Success;
        }

        public string? Message { get; set; }
        public bool Success { get; set; }
        public int? ErrorCode { get; set; }
    }

    public class BaseApiResponse<T> : BaseApiResponse
    {
        public BaseApiResponse()
        {

        }

        public BaseApiResponse(T data, string message)
        {
            Data = data;
            Message = message;
            Success = true;
        }

        public BaseApiResponse(T data, string message, int errorCode)
        {
            Data = data;
            Message = message;
            ErrorCode = errorCode;
            Success = false;
        }

        public T? Data { get; set; }
    }
}
