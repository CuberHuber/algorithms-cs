namespace algorithms_cs.Algorithm.Sort.External.Merge;

public class RotatingDominoes
{
    private List<string> _readFilenames;
    private List<string> _writeFilenames;

    public List<string> ReadFilenames => _readFilenames;
    public List<string> WriteFilenames => _writeFilenames;

    public RotatingDominoes(List<string> readFilenames, List<string> writeFilenames)
    {
        _readFilenames = readFilenames;
        _writeFilenames = writeFilenames;
    }

    public void Rotation()
    {
        (_readFilenames, _writeFilenames) = (_writeFilenames, _readFilenames);
    }
}