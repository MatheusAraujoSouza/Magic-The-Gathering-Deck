namespace Library.Commons.Results
{
    public class ServiceResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ServiceResult(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public static ServiceResult<T> SuccessResult(T data)
        {
            return new ServiceResult<T>(true, string.Empty, data);
        }

        public static ServiceResult<T> ErrorResult(string message)
        {
            return new ServiceResult<T>(false, message, default(T));
        }
    }
}
