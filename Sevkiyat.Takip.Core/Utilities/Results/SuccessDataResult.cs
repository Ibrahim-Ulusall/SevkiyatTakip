﻿namespace Sevkiyat.Takip.Core.Utilities.Results;

public class SuccessDataResult<T> : DataResult<T>
{
    public SuccessDataResult() : base(true)
    {
    }

    public SuccessDataResult(T data) : base(data, true)
    {
    }
    public SuccessDataResult(string message) : base(default, message, true)
    {

    }
    public SuccessDataResult(T data, string message) : base(data, message, true)
    {
    }
}