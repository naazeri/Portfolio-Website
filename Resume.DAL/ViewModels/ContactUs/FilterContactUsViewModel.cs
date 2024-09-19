using System.ComponentModel.DataAnnotations;
using Resume.DAL.ViewModels.Common;

namespace Resume.DAL.ViewModels.ContactUs;

public enum FilterContactUsAnswerStatus
{
  [Display(Name = "All")]
  All,

  [Display(Name = "Answered")]
  Answered,

  [Display(Name = "Not Answered")]
  NotAnswered
}

public class FilterContactUsViewModel : BasePaging<ContactUsDetailsViewModel>
{
  [Display(Name = "Title")]
  public string? Title { get; set; }

  [Display(Name = "Full Name")]
  public string? FullName { get; set; }

  [Display(Name = "Mobile")]
  public string? Mobile { get; set; }

  [Display(Name = "Email")]
  public string? Email { get; set; }

  [Display(Name = "Message")]
  public string? Message { get; set; }

  [Display(Name = "Answer Status")]
  public FilterContactUsAnswerStatus AnswerStatus { get; set; }
}
