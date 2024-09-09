using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interfaces;
using Resume.DAL.ViewModels.Account;

namespace Resume.Web.Controllers;

public class AccountController(IUserService userService) : SiteBaseController
{
  #region Actions

  #region Login

  [HttpGet("/login")]
  public IActionResult Login()
  {
    if (User.Identity?.IsAuthenticated ?? false)
    {
      return RedirectToAction("Index", "Home", new { area = "Admin" });
    }
    return View();
  }

  [HttpPost("/login")]
  public async Task<IActionResult> Login(LoginViewModel model)
  {
    if (!ModelState.IsValid)
    {
      return View(model);
    }

    var result = await userService.LoginAsync(model);

    switch (result)
    {
      case LoginResult.Success:
        var user = await userService.GetByEmailAsync(model.Email);

        if (user == null)
        {
          TempData[ErrorMessage] = "User not found.";
          return View(model);
        }

        #region Authentication

        var claims = new List<Claim>()
                    {
                        new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                        new(ClaimTypes.MobilePhone, user.Mobile)
                    };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        var properties = new AuthenticationProperties
        {
          IsPersistent = true, // remember me
        };

        await HttpContext.SignInAsync(principal, properties);

        TempData[SuccessMessage] = "خوش آمدید!";

        #endregion

        return RedirectToAction("Index", "Home", new { area = "Admin" });

      case LoginResult.UserNotFound:
        TempData[ErrorMessage] = "User not found.";
        return View(model);

      case LoginResult.Error:
        TempData[ErrorMessage] = "Error, please try again.";
        return View(model);
    }

    return View(model);
  }

  #endregion

  #region Logout

  [HttpGet("/logout")]
  public async Task<IActionResult> Logout()
  {
    await HttpContext.SignOutAsync();
    return RedirectToAction("Index", "Home");
  }

  #endregion

  #endregion
}
