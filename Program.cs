// See https://aka.ms/new-console-template for more information

using algorithms_cs.Algorithm.Sort.External.Merge;

const int numberWays = 4;
const string pathFile = "E:\\projects\\algorithms-cs\\resource\\1.test";

var sort = new MultiwaySort(numberWays, pathFile);
sort.Start();