using Resume.DAL.Models.Common;

namespace Resume.DAL.Models;

public class ContactUs : BaseEntity<int>
{
  public string Title { get; set; }
  public string FullName { get; set; }
  public string Mobile { get; set; }
  public string Email { get; set; }
  public string Message { get; set; }
  public string? Answer { get; set; }

}
