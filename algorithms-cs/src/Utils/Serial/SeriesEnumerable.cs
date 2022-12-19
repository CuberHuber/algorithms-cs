using System.Collections;
using algorithms_cs.Utils.Tape;

namespace algorithms_cs.Utils.Serial;

/// <summary>
/// SeriesEnumerable represents Series over the tape like a collection for using foreach
/// Series representing a sequence of increasing numbers over tape.
/// </summary>
public class SeriesEnumerable: IEnumerable<UtilReturn<double>>
{
    private readonly BufferedTapeReader _tape;
    
    public SeriesEnumerable(BufferedTapeReader tape)
    {
        _tape = tape;
        _tape.Peek();
    }

    public bool IsEnd => _tape.Peek().GetType() == UtilReturnType.TapeEnded;

    public IEnumerator<UtilReturn<double>> GetEnumerator()
    {
        return new SeriesEnumerator(_tape);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}