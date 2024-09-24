using System.ComponentModel.DataAnnotations;
using Resume.DAL.Models.Common;
using Resume.DAL.Models.User;

namespace Resume.DAL.Models.File;

public class ImageFile : BaseEntity<int>
{
  #region Properties
  [Required]
  public required string MaxImage { get; set; }

  [Required]
  public required string LargeImage { get; set; }

  [Required]
  public required string ThumbnailImage { get; set; }

  public string? Alt { get; set; }

  [Required]
  public bool IsDeleted { get; set; } = false;

  public int AboutId { get; set; }
  public About About { get; set; } = null!;
  #endregion
}
