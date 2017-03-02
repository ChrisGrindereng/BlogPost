using Microsoft.AspNetCore.Mvc;

[Route("/")]
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index(){
        return View();
    }

    [HttpGet("About")]
    public IActionResult About(){
        return View();
    }
    
    [HttpGet("Contact")]
    public IActionResult Contact(){
        return View();
    }
}

