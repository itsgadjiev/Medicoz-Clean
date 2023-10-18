namespace Porto.Application.Exceptions;

public class NotFoundException : ApplicationException
{
    public object Value { get; }

    public NotFoundException(object value)
    {
        Value = value;
    }

    public NotFoundException() { }
}
