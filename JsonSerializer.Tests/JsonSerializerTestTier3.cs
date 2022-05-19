using NUnit.Framework;

namespace JsonSerializer.Tests;

public class JsonSerializerTestTier3
{
    [Test]
    public void IgnoreNullValues()
    {
        var obj = new Class1()
        {
            Delta = null,
            Epsilon = null,
            Nested = new Class1()
            {
                Delta = null,
                Epsilon = null
            }
        };
        Assert.AreEqual(JsonSerializer.Serialize(obj), "{'Epsilon':null,'Nested':{'Epsilon':null}}");
    }

    class Class1
    {
        [IgnoreNullValues]
        public int? Delta { get; init; }
        public bool? Epsilon { get; init; }
        [IgnoreNullValues]
        public Class1 Nested { get; init; }
    }
}