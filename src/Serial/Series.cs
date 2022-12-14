using algorithms_cs.Tape;

namespace algorithms_cs.Serial;

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