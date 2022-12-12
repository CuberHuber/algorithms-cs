using algorithms_cs.Tape;

namespace algorithms_cs.Serial;

/*public class Series
{
    private BufferedTapeReader _sTape;
    //private bool _batchEnded;
    private Batch _batch;
    //private bool _sourceEnded;
    //private double _buffer;
    
    public bool IsEmpty => _sourceEnded;
    
    public bool BatchEnded => _batchEnded;

    
    public Series(TapeReader tape)
    {
        _batchEnded = false;
        _sourceEnded = false;
        _s = new Stack<double>();
        _sTape = tape;
        _batch = new Batch(_sTape);
    }

    private void Init()
    {
        var initValue = _sTape.Next();
        if (initValue is NothingTapeReturn<double>)
        {
            // Source is over
            _sourceEnded = true;
            _batchEnded = true;
        }
        else
        {
            // Get the first number from the source and put it on the Stack
            _s.Push(initValue.Value);
        }
    }

    public void UpsetSeries()
    {
        if (_sourceEnded) throw new Exception("Upset Series is impossible because TapeReader tape is ended");
        _batchEnded = false;
        //_batch = new Batch(_sTape);
    }

    private TapeReturn<double> Peek()
    {
        var value = _sTape.Next();
        return value;
    }

    public AnySeriesR<double> Next()
    {
        // Если ветка кончилась
        if (_batchEnded) throw new Exception("");

        var value = _sTape.Next();
        var next = Peek();

        if (value is NothingTapeReturn<double> && value.Type == TapeReturnType.TapeEnded)
        {
            // value is empty. tape is over
            _sourceEnded = true;
            return new AnySeriesR<double>(SeriesReturnInfo.SourceEnded);
        }

        if (value is CorrectTapeReturn<double> && next is CorrectTapeReturn<double> && value.Value < next.Value)
        {
            // Batch continues
            return new AnySeriesR<double>(value.Value, SeriesReturnInfo.Correct);
        }

        if (value is CorrectTapeReturn<double> && 
            (
                (next is NothingTapeReturn<double> && next.Type == TapeReturnType.TapeEnded) || 
                (next is CorrectTapeReturn<double> && value.Value > next.Value)
            )
            )
        {
            // Batch ended but Source continues
            _batchEnded = true;
            return new AnySeriesR<double>(value.Value, SeriesReturnInfo.BatchEnded);
        }
        
        // не должно сюда дойти
        return new AnySeriesR<double>(SeriesReturnInfo.BatchEnded);
    }
}*/

public class Series
{
    private readonly BufferedTapeReader _lsTape;
    private double _buffer;

    public Series(BufferedTapeReader tape)
    {
        _buffer = double.MinValue;
        _lsTape = tape;
    }

    public SeriesReturn<double> Next()
    {
        var peekValue = _lsTape.Peek();
        if (peekValue.GetType() == TapeReturnType.Correct)
        {
            if (_buffer <= peekValue.GetValue())
            {
                var value = _lsTape.Next();
                _buffer = value.GetValue();
                return new SeriesReturn<double>(value.GetValue());
            }
            
            return new SeriesReturn<double>(SeriesReturnType.SeriesEnded);
            
            //return new CorrectSeriesReturn<double>(value.Value, SeriesReturnType.Correct);
        }

        return new SeriesReturn<double>(SeriesReturnType.TapeEnded);
    }
}