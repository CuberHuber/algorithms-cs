using algorithms_cs.Serial;
using algorithms_cs.Tape;

namespace algorithms_cs.Algorithm.Sort.External.Merge;


public class MultiwaySort: Sort
{
    private readonly string _sourceFilePath;
    private readonly string _tempDirectory;
    private readonly int _n;
    private RotatingDominoes _dominoes;
    private List<Tape.Tape> _tapes;
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
        
        _tapes = new List<Tape.Tape>();
        _n = N;
        
        var firstFilenames = new List<string>();
        var secondFilenames = new List<string>();
        for (int i = 0; i < _n; i++)
        {
            firstFilenames.Add(string.Format(_templateNameFiles, i.ToString()));
        }
        for (int i = _n; i < _n*2; i++)
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
        File.Copy(outFilename, _sourceFilePath+"-sorted");
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

        var tapeWrites = new List<TapeWriter<double>>();
        foreach (var filename in _dominoes.WriteFilenames)
        {
            tapeWrites.Add(new TapeWriter<double>(filename));
        }
        
        var indexTape = 0;
        if (indexTape >= _n) throw new IndexOutOfRangeException("indexTape out of range tapeWrites");
        
        var s1 = new Series(initTape);
        SeriesReturn<double> value;

        do
        {
            do
            {
                value = s1.Next();
                if (value.GetType() == SeriesReturnType.Correct)
                {
                    tapeWrites[indexTape].Write(value.GetValue());
                }
            } while (value.GetType() == SeriesReturnType.Correct);

            indexTape += 1;
            if (indexTape >= _n) indexTape = 0;
            s1 = new Series(initTape);
        } while (value?.GetType() != SeriesReturnType.TapeEnded);
        
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

        
        var indexTape = 0;
        if (indexTape >= _n) throw new IndexOutOfRangeException("indexTape out of range tapeWrites");
        var multipleSeries = new List<Series>();
        multipleSeries.AddRange(readTapes.Select(tape => new Series(tape)));
        var collector = new Collector(multipleSeries);
        SeriesReturn<double> value;
        do
        {
            do
            {
                value = collector.Next();
                if (value.GetType() == SeriesReturnType.Correct)
                {
                    writeTapes[indexTape].Write(value.GetValue());
                }
            } while (value.GetType() == SeriesReturnType.Correct);
            indexTape += 1;
            if (indexTape >= _n) indexTape = 0;
            multipleSeries = new List<Series>();
            multipleSeries.AddRange(readTapes.Select(tape => new Series(tape)));
            collector = new Collector(multipleSeries);
        } while (!collector.TapeEnded());

        
        foreach (var tape in readTapes) tape.Close();
        foreach (var tape in writeTapes)  tape.Close();

        return indexTape;
    }

}