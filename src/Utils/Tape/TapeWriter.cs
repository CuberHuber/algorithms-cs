namespace algorithms_cs.Utils.Tape;

public class TapeWriter<T> : Tape
{   
    private readonly StreamWriter _file;
    private bool _recorded;

    public bool Recorded => _recorded;

    public TapeWriter(string path)
    {
        try
        {
            _recorded = false;
            _file = new StreamWriter(path);
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
        _file.Write(value!.ToString() + " ");
    }
}