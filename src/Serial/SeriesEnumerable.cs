using System.Collections;
using algorithms_cs.Tape;

namespace algorithms_cs.Serial;

/// <summary>
/// SeriesEnumerable represents Series over the tape like a collection for using foreach
/// Series representing a sequence of increasing numbers over tape.
/// </summary>
public class SeriesEnumerable: IEnumerable<TapeReturn<double>>
{
    private readonly BufferedTapeReader _tape;
    
    public SeriesEnumerable(BufferedTapeReader tape)
    {
        _tape = tape;
        _tape.Peek();
    }

    public bool IsEnd => _tape.Peek().GetType() == TapeReturnType.TapeEnded;

    public IEnumerator<TapeReturn<double>> GetEnumerator()
    {
        return new SeriesEnumerator(_tape);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}