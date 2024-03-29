﻿using System;
using System.Collections.Generic;
using System.IO;
using WebServer.Server.Common;
using WebServer.Server.Enums;
using WebServer.Server.Http;

namespace WebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<HttpRequestMethod, Dictionary<string, Func<HttpRequest, HttpResponse>>> routes;

        public RoutingTable()
            => this.routes = new()
            {
                [HttpRequestMethod.Get] = new(),
                [HttpRequestMethod.Post] = new(),
                [HttpRequestMethod.Put] = new(),
                [HttpRequestMethod.Delete] = new()
            };

        public IRoutingTable Map(
           HttpRequestMethod method,
           string path,
           HttpResponse response)
        {
            Guard.AgainstNull(response, nameof(response));

            return this.Map(method, path, request => response);
        }

        public IRoutingTable Map(HttpRequestMethod method, string path, Func<HttpRequest, HttpResponse> responseFunction)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFunction, nameof(responseFunction));

            this.routes[method][path.ToLower()] = responseFunction;

            return this;
        }

        public IRoutingTable MapGet(string path, HttpResponse response) 
            => MapGet(path, request => response);


        public IRoutingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunction)
            => Map(HttpRequestMethod.Get, path, responseFunction);

        public IRoutingTable MapPost(string path, HttpResponse response) 
            => MapPost(path, requests=> response);

        public IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunction)
            => Map(HttpRequestMethod.Post, path, responseFunction);

        public HttpResponse ExecuteRequest(HttpRequest request)
        {
            var requestMethod = request.Method;
            var requestPath = request.Path.ToLower();

            if (!this.routes.ContainsKey(requestMethod)
                || !this.routes[requestMethod].ContainsKey(requestPath))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            var responseFunction = this.routes[requestMethod][requestPath];

            return responseFunction(request);
        }

        public IRoutingTable MapStaticFiles(string folder = Settings.StaticFilesRootFolder)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var staticFilesFolder = Path.Combine(currentDirectory, folder);
            var staticFiles = Directory.GetFiles(
                staticFilesFolder,
                "*.*",
                SearchOption.AllDirectories);

            foreach (var file in staticFiles)
            {
                var relativePath = Path.GetRelativePath(staticFilesFolder, file);

                var urlPath = "/" + relativePath.Replace("\\", "/");

                this.MapGet(urlPath, request =>
                {
                    var content = File.ReadAllBytes(file);
                    var fileExtension = Path.GetExtension(file).Trim('.');
                    var contentType = HttpContentType.GetByFileExtension(fileExtension);

                    return new HttpResponse(HttpResponseStatusCode.OK)
                        .SetContent(content, contentType);
                });
            }

            return this;
        }
    }
}
