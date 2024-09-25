using System.ComponentModel.DataAnnotations;
using Resume.DAL.Models.File;
using Resume.DAL.Models.User;
using Resume.DAL.ViewModels.Common;

namespace Resume.DAL.ViewModels.AboutMe;

public class SiteSideEditAboutViewModel : BaseDetailsViewModel<int>
{
  [Display(Name = "First Name")]
  [MaxLength(100, ErrorMessage = "The {0} field must be at most {1} characters long.")]
  [DataType(DataType.Text)]
  public string? FirstName { get; set; }

  [Display(Name = "Last Name")]
  [MaxLength(100, ErrorMessage = "The {0} field must be at most {1} characters long.")]
  [DataType(DataType.Text)]
  public string? LastName { get; set; }

  [Display(Name = "My Titles")]
  [MaxLength(150, ErrorMessage = "The {0} field must be at most {1} characters long.")]
  [DataType(DataType.Text)]
  public string? MyTitles { get; set; }

  [Display(Name = "Social Links")]
  public List<SocialLink> SocialLinks { get; set; } = [];

  [Display(Name = "About Image")]
  public ImageFile? AboutImage { get; set; }

  [Display(Name = "Current About Image Preview")]
  public string? AboutImagePreview { get; set; }

  [Display(Name = "Summary")]
  [MaxLength(1000, ErrorMessage = "The {0} field must be at most {1} characters long.")]
  [DataType(DataType.MultilineText)]
  public string? Summary { get; set; }

  [Display(Name = "Current Job Title")]
  [MaxLength(150, ErrorMessage = "The {0} field must be at most {1} characters long.")]
  [DataType(DataType.Text)]
  public string? CurrentJobTitle { get; set; }

  [Display(Name = "Current Job Title Description Top")]
  [MaxLength(1000, ErrorMessage = "The {0} field must be at most {1} characters long.")]
  [DataType(DataType.MultilineText)]
  public string? CurrentJobTitleDescriptionTop { get; set; }

  [Display(Name = "Current Job Title Description Bottom")]
  [MaxLength(1000, ErrorMessage = "The {0} field must be at most {1} characters long.")]
  [DataType(DataType.MultilineText)]
  public string? CurrentJobTitleDescriptionBottom { get; set; }

  [Display(Name = "Mobile")]
  [MaxLength(15, ErrorMessage = "The {0} field must be at most {1} characters long.")]
  public string? Mobile { get; set; }

  [Display(Name = "Email")]
  [MaxLength(100, ErrorMessage = "The {0} field must be at most {1} characters long.")]
  [EmailAddress(ErrorMessage = "Email format is not valid.")]
  public string? Email { get; set; }

  [Display(Name = "Birth Date")]
  [DataType(DataType.Date)]
  public DateOnly? BirthDate { get; set; }

  [Display(Name = "Location")]
  [MaxLength(150, ErrorMessage = "The {0} field must be at most {1} characters long.")]
  [DataType(DataType.Text)]
  public string? Location { get; set; }
}
