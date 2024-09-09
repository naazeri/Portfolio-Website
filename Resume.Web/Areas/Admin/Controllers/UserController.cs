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

        if (result == CreateUserResult.Success)
        {
            return RedirectToAction(nameof(List));
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
                return RedirectToAction(nameof(List));
            case EditUserResult.UserNotFound:
                return NotFound();
            default:
                break;
        }
        #endregion

        return View();
    }
    #endregion
}
