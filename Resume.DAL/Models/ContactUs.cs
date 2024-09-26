using Resume.DAL.Models.Common;

namespace Resume.DAL.Models;

public class ContactUs : BaseEntity<int>
{
  public required string Title { get; set; }
  public required string FullName { get; set; }
  public required string Email { get; set; }
  public required string Message { get; set; }
  public string? Answer { get; set; }

}
