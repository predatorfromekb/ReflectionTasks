using NUnit.Framework;

namespace DIContainer.Tests;

public class DIContainerTestTier3
{
    [Test]
    public void ServiceWithoutChildren()
    {
        var container = new DIContainer();
        container.Register<IRoot, Root>();
        container.Register<IClass1, Class1>();
        container.Configure<IRoot>();
        var root = container.Get<IRoot>();
        var class1 = container.Get<IClass1>();
        Assert.NotNull(root);
        Assert.NotNull(class1);
        Assert.AreEqual(root.Class1, class1);
    }

    class Root : IRoot
    {
        public IClass1 Class1 { get; }

        public Root(IClass1 class1)
        {
            Class1 = class1;
        }
    }

    interface IRoot
    {
        IClass1 Class1 { get; }
    }
    
    class Class1 : IClass1
    {
        
    }

    interface IClass1
    {
        
    }
}