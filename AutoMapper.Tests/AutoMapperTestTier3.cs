using NUnit.Framework;

namespace AutoMapper.Tests;

public class AutoMapperTestTier3
{
    [Test]
    public void MapToPropertiesWithoutSetterOrWithCustomSetter()
    {
        var obj = new InputClass
        {
            Id = 4,
            Title = "Hello"
        };
        var result = AutoMapper.Map<InputClass, OutputClass>(obj);
        Assert.NotNull(result);
        Assert.AreEqual(obj.Id, result.Id);
        Assert.AreEqual(result.Title, "[Hello]");
    }

    class InputClass
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    
    class OutputClass
    {
        public int Id { get; }
        private string title;
        public string Title
        {
            get => title; 
            set => title = "[" + value + "]";
        }
    }
}