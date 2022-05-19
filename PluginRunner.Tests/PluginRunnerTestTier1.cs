using System.Reflection;
using NUnit.Framework;

namespace PluginRunner.Tests;

[Parallelizable(ParallelScope.None)]
public class PluginRunnerTestTier1
{
    private static int Value = 0;
    
    [Test]
    public void LoadFromAssembly()
    {
        var runner = new PluginRunner();
        Assert.AreEqual(Value, 0);
        runner.Run(Assembly.GetExecutingAssembly());
        Assert.AreEqual(Value, 3);
    }
    
    interface IPluginAbstract : IPlugin
    {
        
    }
    abstract class PluginAbstract : IPluginAbstract
    {
    
        public void Run()
        {
            Value+=I;
        }
        protected abstract int I { get; }
    }

    class Plugin : PluginAbstract
    {
        protected override int I => 2;
    }
    
    class Plugin2 : PluginAbstract
    {
        protected override int I => 1;
    }
}