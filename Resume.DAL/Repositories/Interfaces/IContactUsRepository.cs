using Resume.DAL.Models;
using Resume.DAL.ViewModels.ContactUs;

namespace Resume.DAL.Repositories.Interfaces;

public interface IContactUsRepository
{
  Task<FilterContactUsViewModel> GetAllAsync(FilterContactUsViewModel filter);
  Task AddAsync(ContactUs model);
  Task<ContactUs?> GetByIdAsync(int id);
  void Update(ContactUs contactUs);
  Task SaveChangesAsync();
}
