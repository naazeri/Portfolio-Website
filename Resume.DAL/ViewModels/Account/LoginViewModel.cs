using System.ComponentModel.DataAnnotations;

namespace Resume.DAL.ViewModels.Account;

public enum LoginResult { Success, Error, UserNotFound }

public class LoginViewModel
{
  #region Properties

  [Display(Name = "Email")]
  [Required(ErrorMessage = "The {0} field is required.")]
  [EmailAddress(ErrorMessage = "Email format is not valid.")]
  public string Email { get; set; }

  [Display(Name = "Password")]
  [Required(ErrorMessage = "The {0} field is required.")]
  [DataType(DataType.Password)]
  public string Password { get; set; }

  #endregion

}
