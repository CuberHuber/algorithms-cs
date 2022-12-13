// See https://aka.ms/new-console-template for more information

using algorithms_cs.Algorithm.Sort.External.Merge;
using algorithms_cs.Tape;
using algorithms_cs.Serial;

Console.WriteLine(string.Format("fff {0}", "123"));

var mws = new MultiwaySort(3, "Hello");




/*
var b1 = new BufferedTapeReader((string)@"D:\\condig\\algorithm-cs\\resource\\1.test");
var s1 = new Series(b1);
SeriesReturn<double> value;
do
{
    do
    {
        value = s1.Next();
        Console.Write(value.GetType());
        Console.WriteLine(value.GetValue());
    } while (value.GetType() == SeriesReturnType.Correct);
    s1 = new Series(b1);
} while (value?.GetType() != SeriesReturnType.TapeEnded);
*/
