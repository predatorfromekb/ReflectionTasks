using NUnit.Framework;

namespace DIContainer.Tests
{
    
    public class DIContainerTestTier1
    {
        [Test]
        public void ServiceWithoutChildren()
        {
            var container = new DIContainer();
            container.Configure<Cat>();
            var cat = container.Get<Cat>();
            Assert.NotNull(cat);
        }
    
        [Test]
        public void NotRegisteredService()
        {
            var container = new DIContainer();
            container.Configure<Cat>();
            var dog = container.Get<Dog>();
            Assert.Null(dog);
        }

        class Cat
        {
        
        }
    
        class Dog
        {
        
        }
    }
}