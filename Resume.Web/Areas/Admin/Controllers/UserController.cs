using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interfaces;
using Resume.DAL.ViewModels.User;

namespace Resume.Web.Areas.Admin.Controllers;

public class UserController(IUserService userService) : AdminBaseController
{
  #region List
  public async Task<IActionResult> List(FilterUserViewModel filter)
  {
    var model = await userService.GetAllAsync(filter);
    return View(model);
  }
  #endregion

  #region Actions
  #region Create
  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Create(CreateUserViewModel model)
  {
    #region Validations
    if (!ModelState.IsValid)
    {
      return View(model);
    }
    #endregion

    var result = await userService.AddAsync(model);

    switch (result)
    {
      case CreateUserResult.Success:
        TempData[SuccessMessage] = "New user created successfully.";
        return RedirectToAction(nameof(List));

      case CreateUserResult.Error:
        TempData[ErrorMessage] = "Error, please try again.";
        break;
    }

    return View();
  }
  #endregion

  #region Update
  public async Task<IActionResult> Update(int id)
  {
    var model = await userService.GetForEditByIdAsync(id);

    if (model == null)
    {
      return NotFound();
    }

    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Update(EditUserViewModel model)
  {
    #region Validations
    if (!ModelState.IsValid)
    {
      return View(model);
    }
    #endregion

    #region Check result
    var result = await userService.UpdateAsync(model);

    switch (result)
    {
      case EditUserResult.Success:
        TempData[SuccessMessage] = "User updated successfully.";
        return RedirectToAction(nameof(List));

      case EditUserResult.UserNotFound:
        TempData[ErrorMessage] = "User not found.";
        break;

      case EditUserResult.EmailAlreadyExists:
        TempData[ErrorMessage] = "Email already exists.";
        break;

      case EditUserResult.MobileAlreadyExists:
        TempData[ErrorMessage] = "Mobile already exists.";
        break;

      case EditUserResult.Error:
        TempData[ErrorMessage] = "Error, please try again.";
        break;

      default:
        break;
    }
    #endregion

    return View(model);
  }
  #endregion
  #endregion
}
