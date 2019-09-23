using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;

namespace DEPRECATED
{
    class FileMiddleware
    {

        private readonly RequestDelegate _next;
        private FileManager _fm;

        public FileMiddleware(RequestDelegate next, FileManager fm)
        {
            _next = next;
            _fm = fm;
        }

        public async Task Invoke(HttpContext context)
        {
            System.Console.WriteLine($"Path is {context.Request.Path.Value.ToLower()}");
            if (context.Request.Path.Value.ToLower() == "/file" &&
            context.Request.Query.ContainsKey("name"))
            {
                var f = context.Request.Query["name"];
                var ftemp = _fm.GetFileIfExist(f);
                if (ftemp != null)
                {
                    await context.Response.Body.WriteAsync(ftemp, 0, ftemp.Length);
                }
                else
                    context.Response.StatusCode = 403;


            }
            else
                await _next.Invoke(context);
        }
    }
}