using System.Diagnostics;
using algorithms_cs.Serial;

namespace algorithms_cs.Algorithm.Sort.External.Merge;

internal struct MinReturn
{
    public SeriesReturn<double> Element;
    public int Index;
}

public class Collector
{
    private readonly List<Series> _seriesCollection;
    private readonly List<SeriesReturn<double>> _bufferSeriesReturns;

    public Collector(List<Series> seriesCollection)
    {
        _seriesCollection = seriesCollection;
        _bufferSeriesReturns = new List<SeriesReturn<double>>();
        foreach (var seriesReturn in _seriesCollection)
        {
            _bufferSeriesReturns.Add(seriesReturn.Next());
        }
    }

    private MinReturn Min()
    {
        // This method find Correct minimal value from multiple Series
        
        var value = double.MaxValue;
        var minReturn = new MinReturn
        {
            Index = 0
        };

        for (int i = 0; i < _bufferSeriesReturns.Count; i++)
        {
            if (_bufferSeriesReturns[i].GetType() == SeriesReturnType.Correct && value > _bufferSeriesReturns[i].GetValue())
            {
                value = _bufferSeriesReturns[i].GetValue();
                minReturn.Element = _bufferSeriesReturns[i];
                minReturn.Index = i;
            }
        }

        return minReturn;
    }

    public bool IsEmpty()
    {
        return _bufferSeriesReturns.All(x => x.GetType() != SeriesReturnType.Correct);
    }

    public bool TapeEnded()
    {
        return _bufferSeriesReturns.All(x => x.GetType() == SeriesReturnType.TapeEnded);
    }

    public SeriesReturn<double> Next()
    {
        // Returns minimal Correct value from multiple Series, else returns SeriesEnd

        var seriesEnded = IsEmpty();
        if (seriesEnded) return new SeriesReturn<double>(SeriesReturnType.SeriesEnded);

        var minElement = Min();
        
        _bufferSeriesReturns[minElement.Index] = _seriesCollection[minElement.Index].Next();
        return minElement.Element;
    }
}