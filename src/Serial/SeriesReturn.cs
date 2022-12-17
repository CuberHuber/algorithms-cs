using algorithms_cs.Tape;

namespace algorithms_cs.Serial;

/// <summary>
/// SeriesReturnTape representing series type of return value
/// </summary>
[Flags]
public enum SeriesReturnType
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

public class SeriesReturn<T>
{
    private T? _value;
    private SeriesReturnType _type;

    public T? GetValue()
    {
        return _type == SeriesReturnType.Correct ? _value : default;
    }

    public SeriesReturnType GetType()
    {
        return _type;
    }
    
    /// <summary>
    /// Correct is the default series, since if a value is passed, it's already right.
    /// </summary>
    /// <param name="value">any value that to be passed from Series</param>
    public SeriesReturn(T value)
    {
        _value = value;
        _type = SeriesReturnType.Correct;
    }

    public SeriesReturn(SeriesReturnType type)
    {
        _type = type;
    }
}