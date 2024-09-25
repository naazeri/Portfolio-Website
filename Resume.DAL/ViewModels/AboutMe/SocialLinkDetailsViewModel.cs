using Resume.DAL.ViewModels.Common;

namespace Resume.DAL.ViewModels.AboutMe;

public class SocialLinkDetailsViewModel : BaseDetailsViewModel<int>
{
  public string? Title { get; set; }
  public required string LinkAddress { get; set; }
  public string? IconName { get; set; }
  public bool IsActive { get; set; } = true;
}
