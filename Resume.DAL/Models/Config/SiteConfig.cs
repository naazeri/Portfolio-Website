using System.ComponentModel.DataAnnotations;
using Resume.DAL.Models.Common;

namespace Resume.DAL.Models.Config;

public class SiteConfig : BaseEntity<int>
{
  #region Properties
  [Required]
  public required string SiteTitle { get; set; }

  [Required]
  public required string Tagline { get; set; }

  [Required]
  public required string SiteIcon { get; set; }

  public bool ShowAboutSection { get; set; } = true;

  public bool ShowStatsSection { get; set; } = true;

  public bool ShowSkillsSection { get; set; } = true;

  public bool ShowResumeSection { get; set; } = true;

  public bool ShowPortfolioSection { get; set; } = true;

  public bool ShowServicesSection { get; set; } = true;

  public bool ShowTestimonialsSection { get; set; } = true;

  public bool ShowContactSection { get; set; } = true;

  public bool ShowFooter1Section { get; set; } = true;

  public bool ShowFooter2Section { get; set; } = true;
  #endregion
}
