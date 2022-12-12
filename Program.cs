// See https://aka.ms/new-console-template for more information

using algorithms_cs.Tape;
using algorithms_cs.Serial;

Console.WriteLine("Hello, World!");

//var t1 = new TapeReader((string)"E:\\projects\\algorithms-cs\\resource\\1.test");
var b1 = new BufferedTapeReader((string)"E:\\projects\\algorithms-cs\\resource\\1.test");


var s1 = new Series(b1);

/*var value = s1.Next() ?? throw new ArgumentNullException("s1.Next()");
while (value.GetType() == SeriesReturnType.Correct)
{
    Console.Write(value.GetType());
    Console.WriteLine(value.GetValue());
    value = s1.Next();
    
}*/

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
