using System;

namespace JOS.Enumeration;

public class Result
{
    public bool IsSuccess { get; }
    public Error? Error { get; }
    public bool IsFailure => !IsSuccess;

    protected Result(bool isSuccess, Error? error)
    {
        if(isSuccess && error != null)
        {
            throw new InvalidOperationException();
        }

        if(!isSuccess && error == null)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Failure(Error error)
    {
        return new(false, error);
    }

    public static Result<T> Failure<T>(Error error)
    {
        return new(default!, false, error);
    }

    public static Result Success()
    {
        return new(true, null);
    }

    public static Result<T> Success<T>(T value)
    {
        return new(value, true, null);
    }
}

public class Result<T> : Result
{
    private readonly T _value;

    public T Value
    {
        get
        {
            if(!IsSuccess)
            {
                throw new InvalidOperationException();
            }

            return _value;
        }
    }

    protected internal Result(T value, bool isSuccess, Error? error) : base(isSuccess, error)
    {
        _value = value;
    }
}