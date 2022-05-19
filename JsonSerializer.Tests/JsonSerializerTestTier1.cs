using NUnit.Framework;

namespace JsonSerializer.Tests;

public class JsonSerializerTestTier1
{
    [Test]
    public void Null()
    {
        Assert.Null(JsonSerializer.Serialize(null));
    }
    
    [Test]
    public void SimpleObject()
    {
        var obj = new Class1()
        {
            Delta = 1,
            Alpha = "qwe",
            Epsilon = true,
        };
        Assert.AreEqual(JsonSerializer.Serialize(obj), "{'Alpha':'qwe','Delta':1,'Epsilon':true}");
    }
    
    [Test]
    public void SimpleObjectWithNullString()
    {
        var obj = new Class1()
        {
            Delta = 1,
            Alpha = null,
            Epsilon = true,
        };
        Assert.AreEqual(JsonSerializer.Serialize(obj), "{'Alpha':null,'Delta':1,'Epsilon':true}");
    }

    class Class1
    {
        public int Delta { get; init; }
        public string Alpha { get; init; }
        public bool Epsilon { get; init; }
    }
}