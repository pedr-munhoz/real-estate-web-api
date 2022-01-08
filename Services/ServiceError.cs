namespace real_estate_web_api.Services;

public class ServiceError
{
    public ServiceError(string name, string message)
    {
        Name = name;
        Message = message;
    }

    public string Name { get; set; }
    public string Message { get; set; }
}
