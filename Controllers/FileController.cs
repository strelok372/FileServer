using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

public class FileController : Controller
{
    DBC _context;
    string _folderPath;
    
    public FileController(DBC context, IHostingEnvironment host)
    {
        _context = context;
        _folderPath += host.ContentRootPath + "Files/";
    }

    [HttpGet]
    public IActionResult Map(string name)
    {
        if (_context.Maps.Find(name) != null)
            return new PhysicalFileResult(_folderPath + "Maps/" + name, "file/zip");
        return null;
    }

    [HttpGet]
    public IActionResult Mod(string name)
    {
        if (_context.Mods.Find(name) != null)
            return new PhysicalFileResult(_folderPath + "Mods/" + name, "file/zip");
        return null;
    }

    [HttpGet]
    public IActionResult MapList()
    {
        return new JsonResult(_context.Maps.ToArray());
    }

    [HttpGet]
    public IActionResult ModList()
    {
        return Json(_context.Mods.ToArray());
        // return new JsonResult(_context.Mods.ToArray());
    }


}