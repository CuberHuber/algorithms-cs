namespace algorithms_cs.Utils.Tape;

/// <summary>
/// BufferedTapeReader is a wrapper of TapeReader.
/// BufferedTapeReader implements Peek for check next value of TapeReader without losses this value.
/// </summary>
public class BufferedTapeReader: TapeReader
{
    private readonly Queue<double> _buffer;

    public BufferedTapeReader(string path) : base(path)
    {
        _buffer = new Queue<double>();
    }

    public BufferedTapeReader(StreamReader streamReader) : base(streamReader)
    {
        _buffer = new Queue<double>();
    }
    
    /// <summary>
    /// Peek implements safe viewing of the following value from tape;
    /// Peek always returns the value following the current value until the next value is read
    /// </summary>
    /// <returns>next value of Tape</returns>
    public UtilReturn<double> Peek()
    {
        // Если 2 раза подряд вызвать BufferedTapeReader.Peek() то вернутся одинаковое значение
        if (_buffer.TryPeek(out var bufValue))
        {
            return new UtilReturn<double>(bufValue);
        }
        
        var nextValue = base.Next();
        if (nextValue.GetType() is UtilReturnType.TapeEnded)
        {
            return new UtilReturn<double>(UtilReturnType.TapeEnded);
        }
        
        _buffer.Enqueue(nextValue.GetValue());
        return nextValue;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>next value of Tape or buffered previous value</returns>
    public override UtilReturn<double> Next()
    {
        return _buffer.TryDequeue(out var bufValue) 
            ? new UtilReturn<double>(bufValue) 
            : base.Next();
    }
}