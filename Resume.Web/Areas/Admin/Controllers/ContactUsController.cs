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

  public async Task<IActionResult> Details(int id)
  {
    var contactUs = await contactUsService.GetByIdAsync(id);

    if (contactUs == null)
    {
      return NotFound();
    }

    return View(contactUs);
  }

  [HttpPost]
  public async Task<IActionResult> Details(ContactUsDetailsViewModel model)
  {
    #region Validations

    if (!ModelState.IsValid)
    {
      return View(model);
    }

    #endregion

    // var result = await contactUsService.AnswerAsync(model);
    // switch (result)
    // {
    //   case AnswerResult.Success:
    //     TempData[SuccessMessage] = "پاسخ برای این تماس با ما ارسال شد.";
    //     return RedirectToAction("List");

    //   case AnswerResult.ContactUsNotFound:
    //     TempData[ErrorMessage] = "تماس با ما پیدا نشد.";
    //     break;

    //   case AnswerResult.AnswerIsNull:
    //     TempData[ErrorMessage] = "متن پاسخ خالی است.";
    //     break;

    // }

    return View(model);
  }

  #endregion

}
