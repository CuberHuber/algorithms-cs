namespace algorithms_cs.Tape;

public class TapeWriter<T> : Tape
{   
    private readonly StreamWriter _file;
    private bool _recorded;

    public bool Recorded => _recorded;

    public TapeWriter(string filepath) : base(filepath)
    {
        try
        {
            _recorded = false;
            _file = new StreamWriter(Filepath);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void Close()
    {
        _file.Close();
    }

    public void Write(T value)
    {
        _recorded = true;
        _file.Write(value.ToString() + " ");
    }
}