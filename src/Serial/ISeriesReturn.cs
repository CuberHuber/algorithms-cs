using algorithms_cs.Tape;

namespace algorithms_cs.Serial;

public enum SeriesReturnType
{
    Correct,
    SeriesEnded,
    TapeEnded,
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