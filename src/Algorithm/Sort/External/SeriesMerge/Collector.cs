using algorithms_cs.Utils;
using algorithms_cs.Utils.Serial;

namespace algorithms_cs.Algorithm.Sort.External.SeriesMerge;

internal struct MinReturn
{
    public UtilReturn<double> Element;
    public int Index;
}

public class Collector
{
    private readonly List<Series> _seriesCollection;
    private readonly List<UtilReturn<double>> _bufferSeriesReturns;

    public Collector(List<Series> seriesCollection)
    {
        _seriesCollection = seriesCollection;
        _bufferSeriesReturns = new List<UtilReturn<double>>();
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

        for (var i = 0; i < _bufferSeriesReturns.Count; i++)
        {
            if (_bufferSeriesReturns[i].GetType() == UtilReturnType.Correct 
                && value > _bufferSeriesReturns[i].GetValue())
            {
                value = _bufferSeriesReturns[i].GetValue();
                minReturn.Element = _bufferSeriesReturns[i];
                minReturn.Index = i;
            }
        }

        return minReturn;
    }

    private bool IsEmpty() => _bufferSeriesReturns.All(x => x.GetType() != UtilReturnType.Correct);

    public bool TapeEnded() => _bufferSeriesReturns.All(x => x.GetType() == UtilReturnType.TapeEnded);

    public UtilReturn<double> Next()
    {
        // Returns minimal Correct value from multiple Series, else returns SeriesEnd

        var seriesEnded = IsEmpty();
        if (seriesEnded) return new UtilReturn<double>(UtilReturnType.SeriesEnded);

        var minElement = Min();
        
        _bufferSeriesReturns[minElement.Index] = _seriesCollection[minElement.Index].Next();
        return minElement.Element;
    }
}