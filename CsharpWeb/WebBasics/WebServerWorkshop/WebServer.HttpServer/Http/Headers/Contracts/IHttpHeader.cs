namespace WebServer.Server.Headers.Contracts
{
    public interface IHttpHeader
    {
        public string Name { get; }

        public string Value { get; }

    }
}
