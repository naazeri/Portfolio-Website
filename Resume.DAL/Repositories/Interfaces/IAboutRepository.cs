using Resume.DAL.Models.User;

namespace Resume.DAL.Repositories.Interfaces;

public interface IAboutRepository
{
  Task<About?> GetDetailsAsync();
  Task AddAsync(About model);
  void Update(About About);
  Task SaveChangesAsync();
}
