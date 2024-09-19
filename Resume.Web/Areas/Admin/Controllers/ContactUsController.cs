using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interfaces;

namespace Resume.Web.Areas.Admin.Controllers;

public class ContactUsController(IContactUsService contactUsService) : AdminBaseController
{

  public IActionResult Index()
  {
    return View();
  }

}
