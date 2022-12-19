namespace algorithms_cs.Utils.Tape;

/// <summary>
/// Base Tape class
/// </summary>
public class Tape
{
    public readonly string? TapePath;
    
    protected Tape()
    {
    }
    
    protected Tape(string path)
    {
        TapePath = path;
    }
}