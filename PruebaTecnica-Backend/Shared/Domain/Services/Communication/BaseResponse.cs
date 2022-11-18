namespace PruebaTecnica_Backend.Shared.Domain.Services.Communication
{
    public abstract class BaseResponse<T>
    {
        protected BaseResponse(T resource)
        {
            Resource = resource;
            Success = true;
            Message = string.Empty;
        }
        protected BaseResponse(string message)
        {
            Resource = default;
            Success = false;
            Message = message;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Resource { get; set; }
        
    }
}
