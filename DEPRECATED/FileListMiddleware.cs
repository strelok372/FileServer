using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DEPRECATED
{
    class FileListMiddleware
    {
        private readonly RequestDelegate _next;
        private FileManager _fm;

        public FileListMiddleware(RequestDelegate next, FileManager fileManager)
        {
            _fm = fileManager;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string s = context.Request.Path.Value.ToLower();
            context.Request.Path.Value.TrimEnd('/');

            if (s == "/filelist")
            {
                var r = _fm.GetFiles();
                string data = JsonConvert.SerializeObject(r);
                await context.Response.WriteAsync(data);
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}