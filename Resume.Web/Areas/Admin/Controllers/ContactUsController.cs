using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interfaces;
using Resume.DAL.ViewModels.ContactUs;

namespace Resume.Web.Areas.Admin.Controllers;

public class ContactUsController(IContactUsService contactUsService) : AdminBaseController
{

  #region List
  public async Task<IActionResult> List(FilterContactUsViewModel filter)
  {
    var model = await contactUsService.GetAllAsync(filter);
    return View(model);
  }
  #endregion

  #region Details

  public async Task<IActionResult> Answer(int id)
  {
    var contactUs = await contactUsService.GetInfoByIdAsync(id);

    if (contactUs == null)
    {
      return NotFound();
    }

    return View(contactUs);
  }

  [HttpPost]
  public async Task<IActionResult> Answer(ContactUsDetailsViewModel model)
  {
    #region Validations

    if (!ModelState.IsValid)
    {
      return View(model);
    }

    #endregion

    var result = await contactUsService.AnswerAsync(model);
    switch (result)
    {
      case AnswerResult.Success:
        TempData[SuccessMessage] = "Answer sent successfully.";
        return RedirectToAction("List");

      case AnswerResult.ContactUsNotFound:
        TempData[ErrorMessage] = "ContactUs not found.";
        break;

      case AnswerResult.AnswerIsNull:
        TempData[ErrorMessage] = "Answer text is required.";
        break;

    }

    return View(model);
  }

  #endregion

}
