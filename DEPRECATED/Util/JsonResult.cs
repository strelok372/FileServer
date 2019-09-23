using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DEPRECATED
{
    class JsonResult<T> : IActionResult
    {
        T _object;

        public JsonResult(T o)
        {
            _object = o;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            if (_object != null)
                await context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(_object));
        }


    }
}