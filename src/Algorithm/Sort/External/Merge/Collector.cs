using System.Diagnostics;
using algorithms_cs.Serial;

namespace algorithms_cs.Algorithm.Sort.External.Merge;

internal struct MinReturn
{
    public SeriesReturn<double> element;
    public int index;
}

public class Collector
{
    private readonly List<Series> _seriesCollection;
    private List<SeriesReturn<double>> _bufferSeriesReturns;

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
        var minReturn = new MinReturn();
        minReturn.index = 0;

        for (int i = 0; i < _bufferSeriesReturns.Count; i++)
        {
            if (_bufferSeriesReturns[i].GetType() == SeriesReturnType.Correct && value > _bufferSeriesReturns[i].GetValue())
            {
                value = _bufferSeriesReturns[i].GetValue();
                minReturn.element = _bufferSeriesReturns[i];
                minReturn.index = i;
            }
        }

        return minReturn;
    }

    public SeriesReturn<double> Next()
    {
        // Returns minimal Correct value from multiple Series, else returns SeriesEnd

        var seriesEnded = _bufferSeriesReturns.All(x => x.GetType() != SeriesReturnType.Correct);
        if (seriesEnded) return new SeriesReturn<double>(SeriesReturnType.SeriesEnded);

        var minElement = Min();
        
        _bufferSeriesReturns[minElement.index] = _seriesCollection[minElement.index].Next();
        return minElement.element;
    }
}