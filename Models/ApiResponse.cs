
namespace ProductService.Models
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;

    }

    public class SuccessResponse<T> : BaseResponse
    {
        public T Data { get; set; } = default!;

        public static SuccessResponse<T> Create(T data, string message = "Success")
        {
            return new SuccessResponse<T> { Success = true, Data = data, Message = message };
        }
    }
    
   public class ErrorResponse : BaseResponse
    {
        public List<string> Errors { get; set; } = [];

        public static ErrorResponse Create(List<string> errors, string message = "Error")
        {
            return new ErrorResponse { Success = false, Errors = errors, Message = message };
        }
    }

}