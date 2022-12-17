using algorithms_cs.Tape;

namespace algorithms_cs.Serial;

/// <summary>
/// Series representing a sequence of increasing numbers over BufferedTapeReader.
/// </summary>
public class Series
{
    private readonly BufferedTapeReader _lsTape;
    private double _buffer;

    public Series(BufferedTapeReader tape)
    {
        _buffer = double.MinValue;
        _lsTape = tape;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>A next value if it is greater than the previous value</returns>
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
        }
        return new SeriesReturn<double>(SeriesReturnType.TapeEnded);
    }
}