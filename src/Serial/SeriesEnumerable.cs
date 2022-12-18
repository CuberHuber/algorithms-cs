using System.Collections;
using algorithms_cs.Tape;

namespace algorithms_cs.Serial;

/// <summary>
/// SeriesEnumerable represents Series over the tape like a collection for using foreach
/// Series representing a sequence of increasing numbers over tape.
/// </summary>
public class SeriesEnumerable: IEnumerable
{
    private readonly BufferedTapeReader _tape;
    
    public SeriesEnumerable(BufferedTapeReader tape)
    {
        _tape = tape;
    }
    
    public IEnumerator GetEnumerator()
    {
        return new SeriesEnumerator(_tape);
    }
}