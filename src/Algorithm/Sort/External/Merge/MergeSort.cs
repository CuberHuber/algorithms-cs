using algorithms_cs.Tape;

namespace algorithms_cs.Algorithm.Sort.External.Merge;

public class MultiwaySort: Sort
{
    private readonly string _sourceFilePath;
    private readonly int _nWays;
    private List<string> _files;
    private readonly string _TemplateNameFiles = "tempfile-{0}.multiwaymergesort";


    public MultiwaySort(int NWays, string sourceFilePath)
    {
        _files = new List<string>();
        _sourceFilePath = sourceFilePath;
        _nWays = NWays;
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < _nWays * 2; i++)
        {
            _files.Add(string.Format(_TemplateNameFiles, i.ToString()));
        }
    }

    public void Start()
    {
        
    }

    private void TapeSplit()
    {
        
    }

}