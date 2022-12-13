using algorithms_cs.Serial;

namespace algorithms_cs.Algorithm.Sort.External.Merge;


public class Collector
{
    private readonly int _countSeries;
    private readonly Series[] _seriesCollection;

    public Collector(int countSeries, Series[] SeriesCollection)
    {
        _countSeries = countSeries;
        _seriesCollection = SeriesCollection;
        CheckOutInitData();
    }
    
    // Сделалть Тип проверки ( меньше, больше )
    private void CheckOutInitData()
    {
        if (_seriesCollection.Length != _countSeries)
        {
            throw new Exception();
        }
    }

    public SeriesReturn<double> Next()
    {
        
    }
}