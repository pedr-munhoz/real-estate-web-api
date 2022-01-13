namespace real_estate_web_api.Services;

public class ServiceError
{
    public ServiceError(string error, string message, int code)
    {
        Error = error;
        Message = message;
        Code = code;
    }

    public string Error { get; set; }
    public string Message { get; set; }
    public int Code { get; set; }
}
