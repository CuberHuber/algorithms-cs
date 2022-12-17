using System.Collections;

namespace algorithms_cs.Tape;

/// <summary>
/// TapeCollection represents TapeReader like a collection for using foreach
/// </summary>
public class TapeCollection: IEnumerable
{
    private readonly string _path;
    public TapeCollection(string path)
    {
        _path = path;
    }
    
    public IEnumerator GetEnumerator()
    {
        return new TestEnumerator(_path);
    }
} 