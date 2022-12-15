namespace algorithms_cs.Tape;

public class TapeReader : Tape
{
    private readonly StreamReader? _file;

    public TapeReader(string filepath) : base(filepath)
    {
        try
        {
            _file = new StreamReader(Filepath);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    // This methods returns a boolean value describing is the file ended 
    public bool IsEnd => _file!.Peek() == -1;

    public void Close()
    {
        _file?.Close();
    }

    private bool ValueIsDigit(int value)
    {
        return value is >= 48 and <= 57;
    }

    // This methods reading file and returns a next number from this file
    public virtual TapeReturn<double> Next()
    {
        var token = "";
        var tokenIsNumber = false;
        //_isHaveNumber = IsEnd();

        while (!IsEnd)
        {
            var currentChar = _file!.Read();
            var nextChar = _file.Peek();

            tokenIsNumber = !tokenIsNumber
                ? (currentChar == '-' && ValueIsDigit(nextChar)) || ValueIsDigit(currentChar)
                : tokenIsNumber;

            if (!tokenIsNumber) continue;
            
            // Checking negative or float number or continues digit
            tokenIsNumber = ValueIsDigit(currentChar is '.' or ',' or '-'
                ? nextChar
                : currentChar);

            if (!tokenIsNumber)
            {
                if (token.Length > 0)
                {
                    return new TapeReturn<double>(Convert.ToDouble(token.Replace('.', ',')));
                }
                break;
            }

            token += currentChar switch
            {
                '-' => "-",
                '.' => ".",
                ',' => ",",
                _ => (currentChar - 48).ToString()
            };

            if (nextChar == -1)
            {
                //_isHaveNumber = true;
                return new TapeReturn<double>(Convert.ToDouble(token.Replace('.', ',')));
            }
        }
        return new TapeReturn<double>(TapeReturnType.TapeEnded);
    }
}