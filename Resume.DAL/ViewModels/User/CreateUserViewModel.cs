using System.ComponentModel.DataAnnotations;

namespace Resume.DAL.ViewModels.User;

public enum CreateUserResult { Success, Error }

public class CreateUserViewModel
{
  #region Properties

  [Display(Name = "First Name")]
  [Required(ErrorMessage = "The {0} field is required.")]
  [MaxLength(150, ErrorMessage = "The {0} field must be at most {1} characters long.")]
  public string FirstName { get; set; }

  [Display(Name = "Last Name")]
  [Required(ErrorMessage = "The {0} field is required.")]
  [MaxLength(150, ErrorMessage = "The {0} field must be at most {1} characters long.")]
  public string LastName { get; set; }

  [Display(Name = "Mobile")]
  [Required(ErrorMessage = "The {0} field is required.")]
  [MaxLength(15, ErrorMessage = "The {0} field must be at most {1} characters long.")]
  public string Mobile { get; set; }

  [Display(Name = "Email")]
  [Required(ErrorMessage = "The {0} field is required.")]
  [MaxLength(350, ErrorMessage = "The {0} field must be at most {1} characters long.")]
  [EmailAddress(ErrorMessage = "Email format is not valid.")]
  public string Email { get; set; }

  [Display(Name = "Password")]
  [Required(ErrorMessage = "The {0} field is required.")]
  [MaxLength(150, ErrorMessage = "The {0} field must be at most {1} characters long.")]
  public string Password { get; set; }

  [Display(Name = "Is Active?")]
  public bool IsActive { get; set; }

  #endregion
}
