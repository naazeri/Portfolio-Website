using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : AdminBaseController
{
    #region actions
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Blank()
    {
        return View();
    }
    #endregion
}
