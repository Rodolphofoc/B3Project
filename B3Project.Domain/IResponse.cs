using System.Net;

namespace B3Project.Domain
{
    public interface IResponse
    {
        Task<Response> CreateSuccessResponseAsync(object? data, string message = "");
        Task<Response> CreateErrorResponseAsync(HttpStatusCode? statusCode = HttpStatusCode.BadRequest);
        Task<Response> CreateErrorResponseAsync(object? data, HttpStatusCode? statusCode = HttpStatusCode.BadRequest);
    }
}
