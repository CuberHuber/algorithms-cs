namespace algorithms_cs.Tape;

/// <summary>
/// The TapeReader representing the file that contains numbers.
/// By using StreamReader for reading the file and .Next() for extracting the double number.
/// </summary>
public class TapeReader : Tape
{
    private readonly StreamReader? _file;

    /// <summary>
    /// The TapeReader representing the file that contains numbers.
    /// By using StreamReader for reading the file and .Next() for extracting the double number.
    /// </summary>
    /// <param name="path">the path of file</param>
    public TapeReader(string path)
    {
        try
        {
            _file = new StreamReader(path);
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

    /// <summary>
    /// The TapeReader representing the file that contains numbers.
    /// By using StreamReader for reading the file and .Next() for extracting the double number.
    /// </summary>
    /// <param name="streamReader">StreamReader</param>
    public TapeReader(StreamReader streamReader)
    {
        _file = streamReader;
    }

    /// <summary>
    /// Returns true if the file ends
    /// </summary>
    public bool IsEnd => _file!.Peek() == -1;
    
    /// <summary>
    /// Close the StreamReader
    /// </summary>
    public void Close()
    {
        _file?.Close();
    }
    
    private bool ValueIsDigit(int value)
    {
        return value is >= 48 and <= 57;
    }

    /// <summary>
    /// Read next number from the file
    /// </summary>
    /// <returns>a next double number from StreamReader</returns>
    public virtual TapeReturn<double> Next()
    {
        var token = "";
        var tokenIsNumber = false;

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