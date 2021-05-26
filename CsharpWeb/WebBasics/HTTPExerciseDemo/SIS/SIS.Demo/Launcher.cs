﻿using SIS.HTTP.Enums;
using SIS.WebServer;
using SIS.WebServer.Routing;
using SIS.WebServer.Routing.Contracts;
using System;

namespace SIS.Demo
{
    public class Launcher
    {
        public static void Main(string[] args)
        {
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Add(
                HttpRequestMethod.Get,
                "/",
                request => new HomeController().Index(request));

            Server server = new Server(8000, serverRoutingTable);

            server.Run();
        }
    }
}
