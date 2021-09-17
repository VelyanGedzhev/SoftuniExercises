using DummyGame.Engine;
using DummyGame.IO;
using DummyGame.IO.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace NetCoreDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IReader, ConsoleReader>()
                .AddSingleton<IWriter, ConsoleWriter>()
                .AddSingleton<Engine, Engine>()
                .BuildServiceProvider();

            var writer = serviceProvider.GetService<IWriter>();

            writer.Write("Hello");

            var engine = serviceProvider.GetService<Engine>();
            engine.Start();
        }
    }
}
