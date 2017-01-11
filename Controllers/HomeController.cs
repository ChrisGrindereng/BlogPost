using Microsoft.AspNetCore.Mvc;

[Route("/")]
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Root(){
        return View();
    }

    [HttpGet("About")]
    public IActionResult About(){
        return View();
    }
}