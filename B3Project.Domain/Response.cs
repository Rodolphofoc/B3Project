using System.Net;

namespace B3Project.Domain
{

    public sealed class Response<T> : Response, IResponse
    {
        public T Data { get; private set; } = default!;
    }

    public class Error
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public static Error CreateError(string errorCode, string errorMessage) => new Error { ErrorCode = errorCode, ErrorMessage = errorMessage };
    }

    public class Response : IResponse
    {
        public List<Error> Errors { get; private set; }
        public object? Data { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }
        public string Message { get; private set; }

        public Response() => Errors = new List<Error>();

        public Task<Response> CreateSuccessResponseAsync(object? data, string message = "")
        {
            var retult = new Response
            {
                Data = data,
                Message = message,
                StatusCode = HttpStatusCode.OK
            };
            return Task.FromResult(retult);
        }

        public Task<Response> CreateErrorResponseAsync(HttpStatusCode? statusCode = HttpStatusCode.BadRequest)
        {
            var result = new Response
            {
                Data = default,
                StatusCode = statusCode ?? HttpStatusCode.BadRequest
            };
            return Task.FromResult(result);
        }

        public Task<Response> CreateErrorResponseAsync(object? data, HttpStatusCode? statusCode = HttpStatusCode.BadRequest)
        {
            var result = new Response
            {
                Data = data,
                StatusCode = statusCode ?? HttpStatusCode.BadRequest
            };
            return Task.FromResult(result);
        }
    }
}
