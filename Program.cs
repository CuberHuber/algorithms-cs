// See https://aka.ms/new-console-template for more information

using algorithms_cs.Algorithm.Sort.External.Merge;
using algorithms_cs.Tape;
using algorithms_cs.Serial;


var b1 = new BufferedTapeReader((string)"E:\\projects\\algorithms-cs\\resource\\1.test");
var b2 = new BufferedTapeReader((string)"E:\\projects\\algorithms-cs\\resource\\2.test");
var b3 = new BufferedTapeReader((string)"E:\\projects\\algorithms-cs\\resource\\3.test");

var seriesList = new List<Series>();

seriesList.Add(new Series(b1));
seriesList.Add(new Series(b2));
seriesList.Add(new Series(b3));

var collector = new Collector(seriesList);

SeriesReturn<double> value;
do
{
    value = collector.Next();
    Console.Write( value.GetType() == SeriesReturnType.Correct ? value.GetValue() + " " : "");
} while (value.GetType() == SeriesReturnType.Correct);






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
