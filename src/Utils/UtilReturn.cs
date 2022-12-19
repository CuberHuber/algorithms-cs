namespace algorithms_cs.Utils;

/// <summary>
/// SeriesReturnTape representing series type of return value
/// </summary>
[Flags]
public enum UtilReturnType
{
    /// <summary>
    /// Correct using when next value was successfully received
    /// </summary>
    Correct = 1,
    
    /// <summary>
    /// SeriesEnded using when series was ended or next value was not received
    /// </summary>
    SeriesEnded = 2,
    
    /// <summary>
    /// TapeEnded using when tape was ended or next value was not read
    /// </summary>
    TapeEnded = 3,
}

public class UtilReturn<T>
{
    private readonly T? _value;
    private readonly UtilReturnType _type;

    public T? GetValue()
    {
        return _type == UtilReturnType.Correct ? _value : default;
    }

    public UtilReturnType GetType()
    {
        return _type;
    }
    
    
    /// <summary>
    /// Default initialization with TapeEnded type
    /// </summary>
    public UtilReturn()
    {
        _type = UtilReturnType.TapeEnded;
    }
    
    /// <summary>
    /// Correct is the default series, since if a value is passed, it's already right.
    /// </summary>
    /// <param name="value">any value that to be passed from Series</param>
    public UtilReturn(T value)
    {
        _value = value;
        _type = UtilReturnType.Correct;
    }

    public UtilReturn(UtilReturnType type)
    {
        _type = type;
    }
}