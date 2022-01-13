namespace real_estate_web_api.Services;

public class ServiceError
{
    public ServiceError(string name, string message, int code)
    {
        Name = name;
        Message = message;
        Code = code;
    }

    public string Name { get; set; }
    public string Message { get; set; }
    public int Code { get; set; }
}
