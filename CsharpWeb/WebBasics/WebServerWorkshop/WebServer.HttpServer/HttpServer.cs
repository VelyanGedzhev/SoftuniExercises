using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebServer.Server.Http;
using WebServer.Server.Http.Sessions;
using WebServer.Server.Routing;
using WebServer.Server.Services;

namespace WebServer.Server
{
    public class HttpServer
    {

        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener listener;

        private readonly RoutingTable routingTable;
        private readonly ServiceCollection services;

        private HttpServer(
            string ipAddress, 
            int port,
            IRoutingTable routingTable)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;

            this.listener = new TcpListener(this.ipAddress, this.port);

            this.routingTable = (RoutingTable)routingTable;
            this.services = new ServiceCollection();
        }

        private HttpServer(int port, IRoutingTable routingTable)
            : this("127.0.0.1", port, routingTable)
        {
        }

        private HttpServer(IRoutingTable routingTable)
            :this(5000, routingTable)
        {
        }
            
        public static HttpServer WithRoutes(Action<IRoutingTable> routingTableConfig)
        {
            var routingTable = new RoutingTable();

            routingTableConfig(routingTable);

            var httpServer = new HttpServer(routingTable);

            return httpServer;
        }

        public  HttpServer WithServices(Action<IServiceCollection> serviceCollectionConfig)
        {
            serviceCollectionConfig(this.services);
            return this;
        }

        public async Task Start()
        {

            this.listener.Start();

            Console.WriteLine($"Server started on port {port}");
            Console.WriteLine("Listening for requests...");

            while (true)
            {
                var connection = await this.listener.AcceptTcpClientAsync();

                _ = Task.Run(async () =>
                {
                    
                    var networkStream = connection.GetStream();

                    var requestText = await this.ReadRequest(networkStream);
                    //Console.WriteLine(requestText);

                    try
                    {
                        var request = HttpRequest.Parse(requestText, this.services);

                        var response = this.routingTable.ExecuteRequest(request);

                        this.PrepareSession(request, response);

                        this.LogPipeline(requestText, response.ToString());

                        await WriteResponse(networkStream, response);
                    }
                    catch (Exception exception)
                    {
                        await this.HandleError(networkStream, exception);
                    }

                    connection.Close();
                });
            }
        
        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var totalBytes = 0;

            var requestBuilder = new StringBuilder();

            do
            {
                var bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLength);

                totalBytes += bytesRead;

                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too large.");
                }

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }
            while (networkStream.DataAvailable);

            return requestBuilder.ToString();
        }

        private void PrepareSession(HttpRequest request, HttpResponse response)
        {
            if (request.Session.IsNew)
            {
                response.Cookies.Add(HttpSession.SessionCookieName, request.Session.Id);
                request.Session.IsNew = false;
            }
        }

        private async Task HandleError(NetworkStream networkStream, Exception exception)
        {
            var errorMessage = $"{exception.Message} {Environment.NewLine} {exception.StackTrace}";

            var errorResponse = HttpResponse.ForError(errorMessage);

            await WriteResponse(networkStream, errorResponse);
        }


        private void LogPipeline(string request, string response)
        {
            var separator = new string('-', 50);
            var log = new StringBuilder();

            log.AppendLine();
            log.AppendLine(separator);
            log.AppendLine("REQUEST:");
            log.AppendLine(request);
            log.AppendLine();
            log.AppendLine("RESPONSE: ");
            log.AppendLine(response);
            log.AppendLine(separator);

            Console.WriteLine(log);
        }

        private async Task WriteResponse(NetworkStream networkStream, HttpResponse response)
        {

            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

            await networkStream.WriteAsync(responseBytes);


            if (response.HasContent)
            {
                await networkStream.WriteAsync(response.Content);
            }
        }
    }
}
