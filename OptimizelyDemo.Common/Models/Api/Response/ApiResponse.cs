using System.Net;

namespace OptimizelyDemo.Common.Models.Api.Response
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }

        public ApiResponse(HttpStatusCode statusCode, string? message = null, object? data = null)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public static ApiResponse Ok(object? data = null, string? message = "Success") => new ApiResponse(HttpStatusCode.OK, message, data);
        public static ApiResponse BadRequest(string message = "Bad Request") => new ApiResponse(HttpStatusCode.BadRequest, message);
        public static ApiResponse NotFound(string message = "Not Found") => new ApiResponse(HttpStatusCode.NotFound, message);
        public static ApiResponse ExpectationFailed(string message = "Expectation Failed") => new ApiResponse(HttpStatusCode.ExpectationFailed, message);
    }
}
