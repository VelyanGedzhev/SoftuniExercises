using DIContainer.Modules;
using DummyGame.IO;
using DummyGame.IO.Interfaces;

namespace DummyGame.DI
{
    class ConfigureDI : AbstractModule
    {
        public override void Configure()
        {
            CreateMapping<IReader, ConsoleReader>();
            CreateMapping<IWriter, ConsoleWriter>();
            CreateMapping<IWriter, CustomConsoleWriter>();
        }
    }
}
