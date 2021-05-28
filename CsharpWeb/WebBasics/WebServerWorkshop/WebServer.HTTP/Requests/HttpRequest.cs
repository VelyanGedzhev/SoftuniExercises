﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using WebServer.HTTP.Enums;
using WebServer.HTTP.Headers;
using WebServer.HTTP.Requests.Contracts;

namespace WebServer.Server.Http
{
    public class HttpRequest : IHttpRequest
    {

        private const string NEW_LINE = "\r\n";
        public HttpRequestMethod Method { get; set; }

        public string Url { get; set; }

        public HttpHeaderCollection Headers { get; private set; }  

        public string Body { get; private set; }

        public static HttpRequest Parse(string request)
        {
            var lines = request.Split(NEW_LINE);

            var startLine = lines.First().Split(" ");

            var method = ParseHttpMethod(startLine[0]);
            var url = startLine[1];

            var headers = ParseHttpHeaderCollection(lines.Skip(1));

            var bodyLines = lines.Skip(headers.Count + 2).ToArray();
            var body = string.Join(NEW_LINE, bodyLines);

            return new HttpRequest
            {
                Method = method,
                Url = url,
                Headers = headers,
                Body = body
            };
        }

        private static HttpRequestMethod ParseHttpMethod(string method)
        {
            return method.ToUpper() switch
            {
                "GET" => HttpRequestMethod.Get,
                "POST" => HttpRequestMethod.Post,
                "PUT" => HttpRequestMethod.Put,
                "DELETE" => HttpRequestMethod.Delete,
                _ => throw new InvalidOperationException($"Method {method} is not supported.")
            };
        }

        private static HttpHeaderCollection ParseHttpHeaderCollection(IEnumerable<string> headerLines)
        {
            var headerCollection = new HttpHeaderCollection();

            foreach (var headerLine in headerLines)
            {
                if (headerLine == string.Empty)
                {
                    break;
                }

                var indexOfColon = headerLine.IndexOf(":");

                if (indexOfColon < 0)
                {
                    throw new InvalidOperationException("Request is not valid.");
                }

                var header = new HttpHeader
                {
                    Name = headerLine.Substring(0, indexOfColon),
                    Value = headerLine.Substring(indexOfColon + 1).Trim()
                };

                headerCollection.Add(header);
            }

            return headerCollection;
        }

    }
}
