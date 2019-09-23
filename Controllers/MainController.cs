using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

public class MainController : Controller
{
    public IActionResult Index(){
        return View();
    }

    [NonAction]
    public IActionResult Download([FromServices] IHostingEnvironment hosting){
        return PhysicalFile(hosting.ContentRootPath + "/Files/sample", "file/txt");
    }
}