namespace real_estate_web_api.Services;

public class ServiceResult
{
    public ServiceResult(bool success, ServiceError? error = null)
    {
        Success = success;
        Error = error;
    }

    public bool Success { get; set; }
    public ServiceError? Error { get; set; }
}

public class ServiceResult<T> : ServiceResult
{
    public ServiceResult(T content) : base(success: true)
    {
        Content = content;
    }

    public ServiceResult(ServiceError error) : base(success: false, error)
    {
    }

    public T? Content { get; set; }
}
