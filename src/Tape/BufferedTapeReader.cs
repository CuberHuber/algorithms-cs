namespace algorithms_cs.Tape;

public class BufferedTapeReader: TapeReader
{
    private readonly Queue<double> _buffer;

    public BufferedTapeReader(string filepath) : base(filepath)
    {
        _buffer = new Queue<double>();
    }

    public TapeReturn<double> Peek()
    {
        // Если 2 раза подряд вызвать BufferedTapeReader.Peek() то вернутся одинаковое значение
        if (_buffer.TryPeek(out var bufValue))
        {
            return new TapeReturn<double>(bufValue);
        }
        
        var nextValue = base.Next();
        if (nextValue.GetType() is TapeReturnType.TapeEnded)
        {
            return new TapeReturn<double>(TapeReturnType.TapeEnded);
        }
        
        _buffer.Enqueue(nextValue.GetValue());
        return nextValue;
    }

    public override TapeReturn<double> Next()
    {
        return _buffer.TryDequeue(out var bufValue) 
            ? new TapeReturn<double>(bufValue) 
            : base.Next();
    }
}