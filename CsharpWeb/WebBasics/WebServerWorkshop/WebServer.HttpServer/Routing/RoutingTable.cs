﻿using System;
using System.Collections.Generic;
using WebServer.Server.Common;
using WebServer.Server.Enums;
using WebServer.Server.Http;
using WebServer.Server.Responses;

namespace WebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<HttpRequestMethod, Dictionary<string, HttpResponse>> routes;

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
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(response, nameof(response));

            this.routes[method][path] = response;

            return this;
        }

        public IRoutingTable MapGet(
            string path,
            HttpResponse response) => Map(HttpRequestMethod.Get, path, response);

        public IRoutingTable MapPost(
            string path,
            HttpResponse response) => Map(HttpRequestMethod.Post, path, response);


        public HttpResponse MatchRequest(HttpRequest request)
        {
            var requestMethod = request.Method;
            var requestPath = request.Path;

            if (!this.routes.ContainsKey(requestMethod)
                || !this.routes[requestMethod].ContainsKey(requestPath))
            {
                return new NotFoundResponse();
            }

            return this.routes[requestMethod][requestPath];
        }

    }
}
