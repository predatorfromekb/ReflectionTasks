using System;
using NUnit.Framework;

namespace AutoMapper.Tests
{
    public class AutoMapperTestTier2
    {
        [Test]
        public void ObjectWithChangedFields()
        {
            var obj = new InputClass
            {
                Id = 4,
                Title1 = "Some Title",
                Created = DateTime.Now,
            };
            var result = AutoMapper.Map<InputClass, OutputClass>(obj);
            Assert.NotNull(result);
            CheckThatPropertiesAreEqual(obj, result);
        }
        
        [Test]
        public void TypeMismatch()
        {
            var obj = new InputClass2
            {
                Id = 1
            };
            Assert.DoesNotThrow(() => AutoMapper.Map<InputClass2, OutputClass2>(obj));
            var result = AutoMapper.Map<InputClass2, OutputClass2>(obj);
            Assert.AreEqual(result.Id, default(DateTime));
        }
    
        private static void CheckThatPropertiesAreEqual(InputClass obj, OutputClass result)
        {
            Assert.AreEqual(obj.Id, result.Id);
            Assert.AreEqual(obj.Created, result.Created);
            Assert.AreEqual(result.Title2, null);
        } 
    
        class InputClass
        {
            public int Id { get; set; }
            public string Title1 { get; set; }
            public DateTime Created { get; set; }
        }
        
        class OutputClass
        {
            public int Id { get; set; }
            public string Title2 { get; set; }
            public DateTime Created { get; set; }
        }
        
        class InputClass2
        {
            public int Id { get; set; }
        }
        
        class OutputClass2
        {
            public DateTime Id { get; set; }
        }
    }
}