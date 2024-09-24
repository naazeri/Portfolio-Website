using System.ComponentModel.DataAnnotations;
using Resume.DAL.Models.Common;

namespace Resume.DAL.Models.User;

public class SocialLink : BaseEntity<int>
{
  #region Properties
  public string? Title { get; set; }

  [Required]
  public required string LinkAddress { get; set; }

  [Required]
  public string? IconName { get; set; }

  public bool IsActive { get; set; } = true;

  public int AboutId { get; set; }
  public About About { get; set; } = null!;
  #endregion
}
