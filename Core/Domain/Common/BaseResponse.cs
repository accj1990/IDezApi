namespace IDezApi.Domain.Common
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string>? ValidationErrors { get; set; }
        public T? Data { get; set; }

        public BaseResponse()
        {
            IsSuccess = true;
        }
        public BaseResponse(string message)
        {
            IsSuccess = true;
            Message = message;
        }
        public T Value { get; } = default!;
        public BaseResponse(string message, bool success)
        {
            IsSuccess = success;
            Message = message;
        }
        public BaseResponse(T data, string message = "")
        {
            IsSuccess = true;
            Message = message;
            Data = data;
        }
        public BaseResponse(T data)
        {
            IsSuccess = true;
            Data = data;
        }

        public BaseResponse<T> Success(T value) => new(value);

        public BaseResponse<T> Fail(string message) => new(message);

        public BaseResponse<T> BusnessViolation(string message) => new(message, false)
        {
            ValidationErrors = new List<string> { message }
        };
    }
}
