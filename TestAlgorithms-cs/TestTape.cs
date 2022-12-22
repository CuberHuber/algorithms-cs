using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using algorithms_cs.Utils;
using algorithms_cs.Utils.Tape;

namespace TestAlgorithms_cs;

public class TestTape
{
    private const string PathResources = "../../../resource/";

    [Test]
    public void TestDefaultInitialization()
    {
        var utilReturn = new UtilReturn<double>();
        
        Assert.That(utilReturn.GetType() == UtilReturnType.TapeEnded);
    }
    
    [Test]
    public void TestInitializationWithValue()
    {
        const double value = (double)20;
        var utilReturn = new UtilReturn<double>(value);
        
        Assert.That(utilReturn.GetType() == UtilReturnType.Correct && Math.Abs(utilReturn.GetValue() - value) == 0);
    }

    [Test]
    public void TestTapeReader()
    {
        string path = PathResources + "4.test";

        var answer = new List<double>
        {
            -10,
            -9.0,
            -8.0,
            -7.0012,
            -6.0012,
            5,
            4.12,
            3.12
        };

        var tapeResponse = new List<double>();

        var tape = new TapeReader(path);

        for (int i = 0; i < 8; i++)
        {
            tapeResponse.Add(tape.Next().GetValue());
        }

        Assert.AreEqual(tapeResponse, answer);
    }
}