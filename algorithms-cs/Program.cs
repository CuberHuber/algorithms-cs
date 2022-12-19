using algorithms_cs.Algorithm.Sort.External.SeriesMerge;

const int numberWays = 4;
const string pathFile = "@\\algorithms-cs\\resource\\4.txt";

Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);

var sort = new MultiwaySort(numberWays, pathFile);
// sort.Start();



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