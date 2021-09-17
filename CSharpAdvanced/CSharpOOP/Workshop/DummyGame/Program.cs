using DIContainer.Injectors;
using DummyGame.DI;

namespace DummyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureDI module = new ConfigureDI();
            Injector injector = new Injector(module);

            Engine.Engine engine = injector.Inject<Engine.Engine>();
            engine.Start();

        }
    }
}
