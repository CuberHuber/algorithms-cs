using System.Collections;

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

    // This methods reading file and returns a next number from this file
    public virtual TapeReturn<double> Next()
    {
        var token = "";
        bool isNumber = false, isUnSignNumber = false;
        //_isHaveNumber = IsEnd();

        while (!IsEnd)
        {
            var symbol = _file!.Read();
            var nextSymbol = _file.Peek();
            // Если число не началось
            if (!isNumber && !isUnSignNumber)
            {
                // Если число началось с знака: '-'
                if (symbol == '-' && nextSymbol is >= 48 and <= 57)
                {
                    isUnSignNumber = true;
                }
                else if (48 <= symbol && symbol <= 57)
                {
                    isNumber = true;
                }
            }

            // Если число уже начато
            if (isNumber || isUnSignNumber)
            {
                // Если символ точка или запятая и следующий символ число, то продолжить чтение
                if (symbol is '.' or ',' && nextSymbol is >= 48 and <= 57)
                {
                    isNumber = true;
                    isUnSignNumber = true;
                }
                // Если после точки или запятой нет числа, то выходим из цикла
                else if (symbol is '.' or ',' && nextSymbol is < 48 or > 57)
                {
                    isNumber = false;
                    isUnSignNumber = false;
                }
                else if (symbol == '-' && nextSymbol is >= 48 and <= 57)
                {
                    isNumber = true;
                    isUnSignNumber = true;
                }
                else if (symbol is >= 48 and <= 57)
                {
                    isNumber = true;
                    isUnSignNumber = true;
                }
                else
                {
                    isNumber = false;
                    isUnSignNumber = false;
                }

                if (!isNumber && !isUnSignNumber)
                {
                    //_isHaveNumber = token.Length > 0;
                    if (token.Length > 0)
                    {
                        return new TapeReturn<double>(Convert.ToDouble(token.Replace('.', ',')));
                    }
                    break;
                    //return new CorrectTapeReturn<double>(token.Length > 0 ? Convert.ToDouble(token.Replace('.', ',')) : 0.0);
                    //return new CorrectTapeReturn<double>(Convert.ToDouble(token.Replace('.', ',')));
                }

                if (symbol == '-')
                {
                    token += "-";
                }
                else if (symbol == '.')
                {
                    token += ".";
                }
                else if (symbol == ',')
                {
                    token += ",";
                }
                else
                {
                    token += (symbol - 48).ToString();
                }

                if (nextSymbol == -1)
                {
                    //_isHaveNumber = true;
                    return new TapeReturn<double>(Convert.ToDouble(token.Replace('.', ',')));
                }
            }
        }
        return new TapeReturn<double>(TapeReturnType.TapeEnded);
    }
}