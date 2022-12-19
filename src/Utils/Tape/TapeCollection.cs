using System.Collections;

namespace algorithms_cs.Utils.Tape;

/// <summary>
/// TapeCollection represents TapeReader like a collection for using foreach
/// </summary>
public class TapeCollection: IEnumerable
{
    private readonly BufferedTapeReader _tape;
    public TapeCollection(string path)
    {
        _tape = new BufferedTapeReader(path);
    }

    public TapeCollection(BufferedTapeReader tape)
    {
        _tape = tape;
    }
    
    public IEnumerator GetEnumerator()
    {
        return new TapeEnumerator(_tape);
    }
} 