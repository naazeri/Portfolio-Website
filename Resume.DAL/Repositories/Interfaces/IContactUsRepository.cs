using Resume.DAL.Models;

namespace Resume.DAL.Repositories.Interfaces;

public interface IContactUsRepository
{
  #region Methods

  Task AddAsync(ContactUs model);
  Task SaveChangesAsync();

  #endregion
}
