using System;
using NUnit.Framework;

namespace AutoMapper.Tests;

public class AutoMapperTestTier1
{
    [Test]
    public void Null()
    {
        Assert.Null(AutoMapper.Map<InputClass, OutputClass>(null));
    }
    
    [Test]
    public void DefaultObject()
    {
        var obj = new InputClass();
        var result = AutoMapper.Map<InputClass, OutputClass>(obj);
        Assert.NotNull(result);
        CheckThatPropertiesAreEqual(obj, result);
    }
    
    [Test]
    public void ObjectWithChangedFields()
    {
        var obj = new InputClass
        {
            Id = 4,
            Title = "Some Title",
            Created = DateTime.Now,
        };
        var result = AutoMapper.Map<InputClass, OutputClass>(obj);
        Assert.NotNull(result);
        CheckThatPropertiesAreEqual(obj, result!);
    }
    
    [Test]
    public void ReferenceTypePropertiesAreTheSameObject()
    {
        var child = new ChildClass();
        var obj = new InputClass2
        {
            Child = child
        };
        var result = AutoMapper.Map<InputClass2, OutputClass2>(obj);
        Assert.NotNull(result);
        Assert.AreEqual(child, result!.Child);
    }

    private static void CheckThatPropertiesAreEqual(InputClass obj, OutputClass result)
    {
        Assert.AreEqual(obj.Id, result.Id);
        Assert.AreEqual(obj.Title, result.Title);
        Assert.AreEqual(obj.Created, result.Created);
    } 

    class InputClass
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
    }
    
    class OutputClass
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
    }
    
    class InputClass2
    {
        public ChildClass Child { get; set; }
    }
    
    class OutputClass2
    {
        public ChildClass Child { get; set; }
    }

    class ChildClass
    {
        
    }
}