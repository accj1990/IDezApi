namespace IDezApi.Domain.Common
{
    public class BaseOutputModel<T>
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public bool BusinessRuleViolation { get; set; } = false;
        public T? Data { get; set; }

        public BaseOutputModel(T data)
        {
            Data = data;
        }

        public BaseOutputModel(string message, bool isSuccess = false, bool businessRuleViolation = false)
        {
            Message = message;
            IsSuccess = isSuccess;
            BusinessRuleViolation = businessRuleViolation;
        }

        public BaseOutputModel(bool isSuccess, string message, bool businessRuleViolation = false)
        {
            IsSuccess = isSuccess;
            Message = message;
            BusinessRuleViolation = businessRuleViolation;
        }

        public BaseOutputModel(bool isSuccess, T data, string message = "", bool businessRuleViolation = false)
        {
            IsSuccess = isSuccess;
            Data = data;
            Message = message;
            BusinessRuleViolation = businessRuleViolation;
        }

        public BaseOutputModel()
        {
        }
    }
}
