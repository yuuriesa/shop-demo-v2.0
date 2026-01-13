namespace ShopDemo.Utils
{
    public class ServiceResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int StatusCode { get; set; }

        public static ServiceResult<T> SuccessResult(T data, int statusCode = 200) => new ServiceResult<T>() { StatusCode = statusCode, Success = true, Data = data };
        public static ServiceResult<T> ErrorResult(string message, int statusCode) => new ServiceResult<T>() { StatusCode = statusCode, Message = message, Success = false };
    }
}