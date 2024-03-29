﻿using System;
using WebServer.Server.Common;
using WebServer.Server.Enums;
using WebServer.Server.Http;

namespace WebServer.Server.Routing
{
    public interface IRoutingTable
    {
        IRoutingTable MapStaticFiles(string folder = Settings.StaticFilesRootFolder);


        IRoutingTable Map(HttpRequestMethod method, string path, HttpResponse response);

        IRoutingTable Map(HttpRequestMethod method, string path, Func<HttpRequest, HttpResponse> responseFunction);

        IRoutingTable MapGet(string path, HttpResponse response);

        IRoutingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunction);

        IRoutingTable MapPost(string path, HttpResponse response);

        IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunction);
    }
}
