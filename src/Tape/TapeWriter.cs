namespace algorithms_cs.Tape;

public class TapeWriter<T> : Tape
{   
    private readonly StreamWriter _file;
    
    protected TapeWriter(string filepath) : base(filepath)
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

    public void Write(T value)
    {
        _file.Write(value.ToString() + " ");
    }
}