using algorithms_cs.Utils;
using algorithms_cs.Utils.Serial;
using algorithms_cs.Utils.Tape;

namespace algorithms_cs.Algorithm.Sort.External.SeriesMerge;

public class MultiwaySort
{
    private readonly string _sourceFilePath;
    private readonly string _tempDirectory;
    private readonly int _n;
    private RotatingDominoes _dominoes;
    private List<Tape> _tapes;
    private readonly string _templateNameFiles;
    
    public MultiwaySort(int N, string sourceFilePath)
    {
        if (N <= 1) throw new InvalidDataException("");
        
        _sourceFilePath = sourceFilePath;
        
        var directoryName = Path.GetDirectoryName(_sourceFilePath);
        if (directoryName == null) throw new DirectoryNotFoundException();
        
        _tempDirectory = directoryName + "\\temp\\";
        _templateNameFiles = _tempDirectory + "tempfile-{0}.multiwaymergesort";
        Directory.CreateDirectory(_tempDirectory);
        
        _tapes = new List<Tape>();
        _n = N;
        
        var firstFilenames = new List<string>();
        var secondFilenames = new List<string>();
        for (var i = 0; i < _n; i++)
        {
            firstFilenames.Add(string.Format(_templateNameFiles, i.ToString()));
        }
        for (var i = _n; i < _n*2; i++)
        {
            secondFilenames.Add(string.Format(_templateNameFiles, i.ToString()));
        }
        _dominoes = new RotatingDominoes(firstFilenames, secondFilenames);
    }

    public void Start()
    {
        InitTapeSplit();
        int ended;
        do
        {
            _dominoes.Rotation();
            ended = MainRound();
        } while (ended > 1);

        var endFilename = _dominoes.WriteFilenames[0];
        TrashDelete(endFilename);
    }

    private void TrashDelete(string outFilename)
    {
        if (!File.Exists(_sourceFilePath+"-sorted")) File.Copy(outFilename, _sourceFilePath+"-sorted");
        foreach (var filename in _dominoes.ReadFilenames)
        {
            File.Delete(filename);
        }
        foreach (var filename in _dominoes.WriteFilenames)
        {
            File.Delete(filename);
        }
        Directory.Delete(_tempDirectory);
    }

    private void InitTapeSplit()
    { 
        var initTape = new BufferedTapeReader(_sourceFilePath);

        var tapeWrites = _dominoes.WriteFilenames.Select(filename => new TapeWriter<double>(filename)).ToList();

        var indexTape = 0;
        
        var s1 = new Series(initTape);
        UtilReturn<double> value;

        do
        {
            do
            {
                value = s1.Next();
                if (value.GetType() == UtilReturnType.Correct)
                {
                    tapeWrites[indexTape].Write(value.GetValue());
                }
            } while (value.GetType() == UtilReturnType.Correct);

            indexTape += 1;
            if (indexTape >= _n) indexTape = 0;
            s1 = new Series(initTape);
        } while (value?.GetType() != UtilReturnType.TapeEnded);
        
        foreach (var tape in tapeWrites)
        {
            tape.Close();
        }
    }

    private int MainRound()
    {
        
        // создаются N серий из RotatingDominoes.ReadFilenames
        // Подаются в Collector 
        // Чтение из коллектора серии в один файл
        
        // следующая серия коллектора в другой файл и по i (mod N)
        
        // ПОМОГИТЕ, МЕНЯ ДЕРЖАТ В ЗАЛОЖНИКАХ, НЕТ НЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕТ НЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕТ
        
        
        // Создание Списка полос для чтения
        var readTapes = new List<BufferedTapeReader>();
        if (readTapes == null) throw new ArgumentNullException(nameof(readTapes));
        readTapes.AddRange(_dominoes.ReadFilenames.Select(filename => new BufferedTapeReader(filename)));
        
        // Создание Списка полос для записи
        var writeTapes = new List<TapeWriter<double>>();
        if (writeTapes == null) throw new ArgumentNullException(nameof(readTapes));
        writeTapes.AddRange(_dominoes.WriteFilenames.Select(filename => new TapeWriter<double>(filename)));

        var count = 0;
        var indexTape = 0;
        if (indexTape >= _n) throw new IndexOutOfRangeException("indexTape out of range tapeWrites");
        var multipleSeries = new List<Series>();
        multipleSeries.AddRange(readTapes.Select(tape => new Series(tape)));
        var collector = new Collector(multipleSeries);
        UtilReturn<double> value;
        do
        {
            do
            {
                value = collector.Next();
                if (value.GetType() == UtilReturnType.Correct)
                {
                    writeTapes[indexTape].Write(value.GetValue());
                }
            } while (value.GetType() == UtilReturnType.Correct);

            count++;
            if (count > 2) count = 2;
            indexTape++;
            if (indexTape >= _n) indexTape = 0;
            multipleSeries = new List<Series>();
            multipleSeries.AddRange(readTapes.Select(tape => new Series(tape)));
            collector = new Collector(multipleSeries);
        } while (!collector.TapeEnded());

        
        foreach (var tape in readTapes) tape.Close();
        foreach (var tape in writeTapes)  tape.Close();

        return count;
    }

}