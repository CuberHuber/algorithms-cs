// See https://aka.ms/new-console-template for more information

using algorithms_cs.Algorithm.Sort.External.SeriesMerge;

const int numberWays = 4;
const string pathFile = "E:\\projects\\algorithms-cs\\resource\\4.txt";

var sort = new MultiwaySort(numberWays, pathFile);
sort.Start();

//
// var test = new BufferedTapeReader(pathFile);
// var test2 = new TapeCollection(pathFile);
// var ss = new SeriesEnumerable(test);
//
// foreach (var VARIABLE in test2)
// {
//     Console.WriteLine(VARIABLE);
// }
//
// while (!ss.IsEnd)
// {
//     foreach (var VARIABLE in ss)
//     {
//         Console.WriteLine($"{VARIABLE.GetType()}   {VARIABLE.GetValue()}");
//     }
//     Console.WriteLine();
// }


