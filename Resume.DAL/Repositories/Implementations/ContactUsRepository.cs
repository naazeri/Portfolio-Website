using Resume.DAL.Context;
using Resume.DAL.Models;
using Resume.DAL.Repositories.Interfaces;

namespace Resume.DAL.Repositories.Implementations;

public class ContactUsRepository(AppDbContext context) : IContactUsRepository
{
  #region Methods

  public async Task AddAsync(ContactUs model)
  {
    await context.ContactUs.AddAsync(model);
  }

  public async Task SaveChangesAsync()
  {
    await context.SaveChangesAsync();
  }

  #endregion
}
