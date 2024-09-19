using Resume.DAL.ViewModels.Common;

namespace Resume.DAL.ViewModels.User;

public class UserDetailsViewModel : BaseDetailsViewModel<int>
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Mobile { get; set; }
  public string Email { get; set; }
  public bool IsActive { get; set; }
}
