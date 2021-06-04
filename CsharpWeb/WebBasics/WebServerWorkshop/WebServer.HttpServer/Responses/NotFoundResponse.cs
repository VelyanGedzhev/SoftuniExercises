﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Server.Enums;

namespace WebServer.Server.Responses
{
    public class NotFoundResponse : HttpResponse
    {
        public NotFoundResponse() 
            : base(HttpResponseStatusCode.NotFound)
        {
        }
    }
}
