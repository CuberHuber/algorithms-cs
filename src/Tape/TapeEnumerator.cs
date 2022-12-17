using System.Collections;

namespace algorithms_cs.Tape;

public class TapeEnumerator : IEnumerator
{
    private BufferedTapeReader _tape;
    private readonly string? _path;
    
    public TapeEnumerator(string path)
    {
        _path = path;
        _tape = new BufferedTapeReader(path);
    }

    public TapeEnumerator(BufferedTapeReader tape)
    {
        _path = tape.TapePath;
        _tape = tape;
    }
    
    /// <summary>
    /// Checks that the Tape is finished or there is no next number
    /// </summary>
    /// <returns>boolean indicating whether a next number is available</returns>
    public bool MoveNext()
    {
        return !_tape.IsEnd || _tape.Peek().GetType() == TapeReturnType.Correct;
    }

    public void Reset()
    {
        _tape = new BufferedTapeReader(_path);
    }
    
    /// <summary>
    /// Returns a next number from the tape 
    /// </summary>
    public object Current => _tape.Next().GetValue();
}