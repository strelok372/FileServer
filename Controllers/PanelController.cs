using Microsoft.AspNetCore.Mvc;

public class ManagementController : Controller
{
    DoomRepo _repo;

    public ManagementController(DoomRepo repo){
        _repo = repo;
    }

    public IActionResult Control(){
        ViewBag.ListMap = 
        return View();
    }
    
    [HttpPost]
    void Add(){

    }
    
    [HttpDelete]
    void Delete(){

    }

    [HttpPut]
    void Update(){

    }
    
}