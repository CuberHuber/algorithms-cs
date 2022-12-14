namespace algorithms_cs.Tape;

public class TapeWriter<T> : Tape
{   
    private readonly StreamWriter _file;

    public TapeWriter(string filepath) : base(filepath)
    {
        try
        {
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
        _file.Write(value.ToString() + " ");
    }
}