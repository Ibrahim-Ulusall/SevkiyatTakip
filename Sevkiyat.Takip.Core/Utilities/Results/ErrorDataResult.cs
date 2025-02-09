namespace Sevkiyat.Takip.Core.Utilities.Results;

public class ErrorDataResult<T> : DataResult<T>
{
    public ErrorDataResult() : base(false)
    {
    }

    public ErrorDataResult(T data) : base(data, false)
    {
    }
    public ErrorDataResult(string message):base(default,message,false)
    {

    }
    public ErrorDataResult(T data, string message) : base(data, message, false)
    {
    }
}
