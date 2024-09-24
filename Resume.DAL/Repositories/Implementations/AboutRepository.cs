using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.User;
using Resume.DAL.Repositories.Interfaces;

namespace Resume.DAL.Repositories.Implementations;

public class AboutRepository(AppDbContext context) : IAboutRepository
{
  public async Task<About?> GetDetailsAsync()
  {
    return await context.About
    .Include(x => x.SocialLinks)
    .Include(x => x.AboutImage)
    .FirstOrDefaultAsync();
  }

  public async Task AddAsync(About model)
  {
    await context.About.AddAsync(model);
  }

  public void Update(About contactUs)
  {
    context.About.Update(contactUs);
  }

  public async Task SaveChangesAsync()
  {
    await context.SaveChangesAsync();
  }
}
