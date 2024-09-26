using Resume.DAL.Models.Common;
using Resume.DAL.Models.File;

namespace Resume.DAL.Models.User;

public class About : BaseEntity<int>
{
  #region Properties
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public string? MyTitles { get; set; }
  public List<SocialLink> SocialLinks { get; set; } = [];
  public int ImageFileId { get; set; }
  public ImageFile? AboutImage { get; set; }
  public string? Summary { get; set; }
  public string? CurrentJobTitle { get; set; }
  public string? CurrentJobTitleDescriptionTop { get; set; }
  public string? CurrentJobTitleDescriptionBottom { get; set; }
  public string? Mobile { get; set; }
  public string? Email { get; set; }
  public DateOnly? BirthDate { get; set; }
  public string? Location { get; set; }
  #endregion
}
