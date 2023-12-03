namespace Medicoz.Application.Exceptions;

public class NotFoundException : ApplicationException
{
    public object Value { get; }
    public string Key { get; }
    public string ErrorMessage { get; }

    public NotFoundException(object value)
    {
        Value = value;
    }
    public NotFoundException(string key, string errorMessage)
    {
        Key = key;
        ErrorMessage = errorMessage;
    }
    public NotFoundException() { }
}
