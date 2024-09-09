using System.ComponentModel.DataAnnotations;
using Resume.DAL.ViewModels.Common;

namespace Resume.DAL.ViewModels.User;

public class FilterUserViewModel : BasePaging<UserDetailsViewModel>
{
  [Display(Name = "Mobile")]
  [MaxLength(15, ErrorMessage = "The {0} field must be at most {1} characters long.")]
  public string? Mobile { get; set; }

  [Display(Name = "Email")]
  [MaxLength(350, ErrorMessage = "The {0} field must be at most {1} characters long.")]
  public string? Email { get; set; }

}