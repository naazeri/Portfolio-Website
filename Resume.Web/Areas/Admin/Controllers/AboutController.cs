using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interfaces;
using Resume.DAL.ViewModels.AboutMe;

namespace Resume.Web.Areas.Admin.Controllers;

public class AboutController(IAboutService aboutService) : AdminBaseController
{
  #region Update
  public async Task<IActionResult> Update()
  {
    var model = await aboutService.GetDetailsForAdminAsync();
    return View(model);
  }

  [HttpPost]
  public async Task<IActionResult> Update(AdminSideEditAboutViewModel model)
  {
    if (!ModelState.IsValid)
    {
      return View(model);
    }

    var result = await aboutService.UpdateAsync(model);

    switch (result)
    {
      case AdminSideEditAboutResult.Success:
        TempData[SuccessMessage] = "About updated successfully.";
        return RedirectToAction(nameof(Update));

      case AdminSideEditAboutResult.Error:
        TempData[ErrorMessage] = "Error, please try again.";
        break;

      default:
        break;
    }


    return View(model);
  }

  #endregion

}
