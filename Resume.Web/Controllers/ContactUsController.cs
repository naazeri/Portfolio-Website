using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interfaces;
using Resume.DAL.ViewModels.ContactUs;

namespace Resume.Web.Controllers;

public class ContactUsController(IContactUsService contactUsService) : SiteBaseController
{

  [HttpGet("/contact-us")]
  public IActionResult ContactUs()
  {
    return View();
  }

  [HttpPost("/contact-us")]
  public IActionResult ContactUs(CreateContactUsViewModel model)
  {
    if (!ModelState.IsValid)
    {
      return View(model);
    }

    var result = contactUsService.AddAsync(model);

    switch (result.Result)
    {
      case CreateContactUsResult.Success:
        TempData[SuccessMessage] = "Message sent successfully";
        return RedirectToAction(nameof(ContactUs));

      case CreateContactUsResult.Error:
        TempData[ErrorMessage] = "Error, please try again";
        return View("Error");
    }

    return View(result);
  }

}
