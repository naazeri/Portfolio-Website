using System.ComponentModel.DataAnnotations;

namespace Resume.DAL.ViewModels.ContactUs;

public enum CreateContactUsResult { Success, Error }

public class CreateContactUsViewModel
{
  #region Properties

  [Display(Name = "Title")]
  [Required(ErrorMessage = "The {0} field is required.")]
  [MaxLength(300, ErrorMessage = "The {0} field must be at most {1} characters long.")]
  public string Title { get; set; }

  [Display(Name = "FullName")]
  [Required(ErrorMessage = "The {0} field is required.")]
  [MaxLength(150, ErrorMessage = "The {0} field must be at most {1} characters long.")]
  public string FullName { get; set; }

  [Display(Name = "Mobile")]
  [MaxLength(15, ErrorMessage = "The {0} field must be at most {1} characters long.")]
  public string? Mobile { get; set; }

  [Display(Name = "Email")]
  [Required(ErrorMessage = "The {0} field is required.")]
  [MaxLength(250, ErrorMessage = "The {0} field must be at most {1} characters long.")]
  [EmailAddress(ErrorMessage = "Email format is not valid.")]
  public string Email { get; set; }

  [Display(Name = "Message")]
  [Required(ErrorMessage = "The {0} field is required.")]
  [MinLength(10, ErrorMessage = "The {0} field must be at least {1} characters long.")]
  [MaxLength(1000, ErrorMessage = "The {0} field must be at most {1} characters long.")]
  public string Message { get; set; }

  #endregion
}
