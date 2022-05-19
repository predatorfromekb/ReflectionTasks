using NUnit.Framework;

namespace JsonSerializer.Tests
{
    public class JsonSerializerTestTier2
    {
        [Test]
        public void SimpleObjectWithNullString()
        {
            var obj = new Class1()
            {
                Delta = 1,
                Epsilon = true,
                Nested = new Class1()
                {
                    Delta = 2,
                    Epsilon = false
                }
            };
            Assert.AreEqual(JsonSerializer.Serialize(obj), "{'Delta':1,'Epsilon':true,'Nested':{'Delta':2,'Epsilon':false,'Nested':null}}");
        }
        
        [Test]
        public void NullableTypes()
        {
            var obj = new Class2()
            {
                Delta = null,
                Epsilon = null,
            };
            Assert.AreEqual(JsonSerializer.Serialize(obj), "{'Delta':null,'Epsilon':null}");
        }
        
        [Test]
        public void Arrays()
        {
            var obj = new[]
            {
                new Class2()
                {
                    Delta = 1,
                    Epsilon = true,
                },
                new Class2()
                {
                    Delta = 2,
                    Epsilon = false,
                },
                null
            };
            Assert.AreEqual(JsonSerializer.Serialize(obj), "[{'Delta':1,'Epsilon':true},{'Delta':2,'Epsilon':false},null]");
        }
    
        class Class1
        {
            public int Delta { get; init; }
            public bool Epsilon { get; init; }
            public Class1 Nested { get; init; }
        }
        
        class Class2
        {
            public int? Delta { get; init; }
            public bool? Epsilon { get; init; }
        }
    }
}