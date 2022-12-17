namespace algorithms_cs.Tape;

/// <summary>
/// TapeReturnType representing tape of return value 
/// </summary>
[Flags]
public enum TapeReturnType
{
    /// <summary>
    /// Correct using when next value was successfully read 
    /// </summary>
    Correct = 1,
    
    /// <summary>
    /// TapeEnded using when tape was ended or next value was not read
    /// </summary>
    TapeEnded = 2,
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class TapeReturn<T>
{
    private T? _value;
    private TapeReturnType _type;

    public T? GetValue()
    {
        return _type == TapeReturnType.Correct ? _value : default;
    }

    public TapeReturnType GetType()
    {
        return _type;
    }

    /// <summary>
    /// Default initialization with TapeEnded type
    /// </summary>
    public TapeReturn()
    {
        _type = TapeReturnType.TapeEnded;
    }

    /// <summary>
    /// Correct is the default type, since if a value is passed, it's already right.
    /// </summary>
    /// <param name="value">any value that to be passed from Tape</param>
    public TapeReturn(T value)
    {
        _value = value;
        _type = TapeReturnType.Correct;
    }

    public TapeReturn(TapeReturnType type)
    {
        _type = type;
    }
}
