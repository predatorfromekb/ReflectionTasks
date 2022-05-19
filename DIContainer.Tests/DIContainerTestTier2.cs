using NUnit.Framework;

namespace DIContainer.Tests
{
    public class DIContainerTestTier2
{
    [Test]
    public void ServiceWithChildren()
    {
        var container = new DIContainer();
        container.Configure<Root>();
        var root = container.Get<Root>();
        Assert.NotNull(root);
        Assert.NotNull(root.Class2.Class3.Class1);
    }
    
    [Test]
    public void ServicesAreSingleton()
    {
        var container = new DIContainer();
        container.Configure<Root>();
        var root = container.Get<Root>();
        var class1 = container.Get<Class1>();
        Assert.NotNull(root);
        Assert.AreEqual(class1, root.Class2.Class1);
        Assert.AreEqual(class1, root.Class2.Class1);
        Assert.AreEqual(class1, root.Class2.Class3.Class1);
    }
    
    [Test]
    public void ServicesAreSingleton2()
    {
        var container = new DIContainer();
        container.Configure<Root>();
        var root = container.Get<Root>();
        var root2 = container.Get<Root>();
        Assert.NotNull(root);
        Assert.NotNull(root2);
        Assert.AreEqual(root.Class1, root2.Class1);
    }
    
    [Test]
    public void ServicesAreSingletonOnlyByContainerInstance()
    {
        var container = new DIContainer();
        var container2 = new DIContainer();
        container.Configure<Root>();
        container2.Configure<Root>();
        var root = container.Get<Root>();
        var root2 = container2.Get<Root>();
        Assert.NotNull(root);
        Assert.NotNull(root2);
        Assert.AreNotEqual(root.Class1, root2.Class1);
    }

    class Root
    {
        // Как правило зависимости делают приватными, но я их намеренно сделал публичными
        public readonly Class1 Class1;
        public readonly Class2 Class2;

        public Root(Class1 class1, Class2 class2)
        {
            Class1 = class1;
            Class2 = class2;
        }
    }
    
    class Class1
    {
        
    }
    
    class Class2
    {
        public readonly Class1 Class1;
        public readonly Class3 Class3;

        public Class2(Class1 class1, Class3 class3)
        {
            Class1 = class1;
            Class3 = class3;
        }
    }
    
    class Class3
    {
        public readonly Class1 Class1;

        public Class3(Class1 class1)
        {
            Class1 = class1;
        }
    }
}
}