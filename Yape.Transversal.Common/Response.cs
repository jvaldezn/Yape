namespace Yape.Transversal.Common
{
    public class Response<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;

        public static Response<T> Success(T data, string message = "")
        {
            return new Response<T> { Data = data, IsSuccess = true, Message = message };
        }

        public static Response<T> Fail(string message)
        {
            return new Response<T> { IsSuccess = false, Message = message };
        }
    }
}
