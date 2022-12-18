using System.Collections;
using algorithms_cs.Tape;

namespace algorithms_cs.Serial;

public class SeriesEnumerator: IEnumerator
{
    private readonly BufferedTapeReader _tape;
    private double _previous;
    
    public SeriesEnumerator(BufferedTapeReader tape)
    {
        _tape = tape;
        _previous = double.MinValue;
    }
    
    /// <summary>
    /// Checks a correct of next number
    /// </summary>
    /// <returns>boolean indicating whether a next number is available and more than the previous number</returns>
    public bool MoveNext()
    {
        var value = _tape.Peek();
        if (value.GetType() == TapeReturnType.Correct)
        {
            if (_previous <= value.GetValue())
            {
                _previous = value.GetValue();
                return true;
            }
        }
        return false;
    }

    public void Reset()
    {
    }

    public object Current => _tape.Next().GetValue();
}