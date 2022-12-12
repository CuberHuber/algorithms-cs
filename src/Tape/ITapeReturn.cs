namespace algorithms_cs.Tape;


public enum TapeReturnType
{
    Correct,
    TapeEnded,
}

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
