using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Controllers;

public class HomeController() : SiteBaseController
{

  public IActionResult Index()
  {
    return View();
  }

  public IActionResult Starter()
  {
    return View();
  }

}
