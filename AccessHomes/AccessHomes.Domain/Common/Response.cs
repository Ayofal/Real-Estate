using System.Collections.Generic;

namespace AccessHomes.Domain.Common
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public Response(T data, Pagination meta, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
            Meta = meta;
        }

        public Response(string message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
        }
        public Response(string message)
        {
            Succeeded = true;
            Message = message;
        }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
        public Pagination Meta { get; set; }
    }
}
