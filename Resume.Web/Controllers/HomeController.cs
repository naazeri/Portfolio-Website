using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Starter()
    {
        return View();
    }

}
