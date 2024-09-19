using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interfaces;
using Resume.DAL.ViewModels.ContactUs;

namespace Resume.Web.Controllers;

public class HomeController(IContactUsService contactUsService) : SiteBaseController
{

  public IActionResult Index()
  {
    return View();
  }

  [HttpPost()]
  public async Task<IActionResult> Index(CreateContactUsViewModel model)
  {
    ViewData["ScrollToContact"] = true;

    if (!ModelState.IsValid)
    {
      return View(model);
    }

    var result = await contactUsService.AddAsync(model);

    switch (result)
    {
      case CreateContactUsResult.Success:
        TempData[SuccessMessage] = "Message sent successfully";
        break;

      case CreateContactUsResult.Error:
        TempData[ErrorMessage] = "Error, please try again";
        return View("Error");
    }

    return View();
  }

  public IActionResult Starter()
  {
    return View();
  }

}
