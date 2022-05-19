namespace PluginRunner.Plugin
{
    public class Plugin : IPlugin
    {
        public void Run()
        {
            Counter.Value += 50;
        }
    }

    public class Plugin2 : IPlugin
    {
        public void Run()
        {
            Counter.Value += 100;
        }
    }
}