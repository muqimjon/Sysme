namespace Sysme.Service.Exceptions;

internal class CustomException : Exception
{
    public CustomException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }

    public CustomException(int statusCode, string message, Exception innerException) : base(message, innerException) 
    {
        StatusCode = statusCode;
    }

    public int StatusCode { get; set; }
}
