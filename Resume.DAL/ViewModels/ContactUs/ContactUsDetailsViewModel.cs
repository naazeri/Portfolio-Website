using System.ComponentModel.DataAnnotations;
using Resume.DAL.ViewModels.Common;

namespace Resume.DAL.ViewModels.ContactUs;

public enum AnswerResult
{
  Success,
  ContactUsNotFound,
  Error,
  AnswerIsNull
}

public class ContactUsDetailsViewModel : BaseDetailsViewModel<int>
{
  #region Properties
  public string? Title { get; set; }

  public string? FullName { get; set; }

  public string? Mobile { get; set; }

  public string? Email { get; set; }

  public string? Message { get; set; }

  [Display(Name = "Answered")]
  [Required(ErrorMessage = "The {0} field is required.")]
  public string? Answer { get; set; }
  #endregion
}

