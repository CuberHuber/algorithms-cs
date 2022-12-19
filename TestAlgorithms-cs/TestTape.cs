using System;
using NUnit.Framework;
using algorithms_cs.Utils;

namespace TestAlgorithms_cs;

public class TestTape
{
    
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
}