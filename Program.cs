// See https://aka.ms/new-console-template for more information

using algorithms_cs.Algorithm.Sort.External.Merge;
using algorithms_cs.Algorithm.Sort.External.SeriesMerge;
using algorithms_cs.Tape;

const int numberWays = 4;
const string pathFile = "E:\\projects\\algorithms-cs\\resource\\1.test";

var sort = new MultiwaySort(numberWays, pathFile);
sort.Start();


var test = new TapeCollection(pathFile);
foreach (var t in test)
{
    Console.WriteLine(t);
}
