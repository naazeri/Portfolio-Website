using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models;
using Resume.DAL.Repositories.Interfaces;
using Resume.DAL.ViewModels.ContactUs;

namespace Resume.DAL.Repositories.Implementations;

public class ContactUsRepository(AppDbContext context) : IContactUsRepository
{
  public async Task<FilterContactUsViewModel> GetAllAsync(FilterContactUsViewModel filter)
  {
    var query = context.ContactUs.OrderByDescending(x => x.CreateDate)
      .AsQueryable();

    #region Filter
    if (!string.IsNullOrEmpty(filter.Title))
    {
      query = query
        .Where(x => EF.Functions.Like(x.Title, $"%{filter.Title}%"));
    }

    if (!string.IsNullOrEmpty(filter.FullName))
    {
      query = query
        .Where(x => EF.Functions.Like(x.FullName, $"%{filter.FullName}%"));
    }

    if (!string.IsNullOrEmpty(filter.Mobile))
    {
      query = query
        .Where(x => EF.Functions.Like(x.Mobile, $"%{filter.Mobile}%"));
    }

    if (!string.IsNullOrEmpty(filter.Email))
    {
      query = query
        .Where(x => EF.Functions.Like(x.Email, $"%{filter.Email}%"));
    }

    if (!string.IsNullOrEmpty(filter.Message))
    {
      query = query
        .Where(x => EF.Functions.Like(x.Message, $"%{filter.Message}%"));
    }

    switch (filter.AnswerStatus)
    {
      case FilterContactUsAnswerStatus.Answered:
        query = query.Where(x => x.Answer != null);
        break;

      case FilterContactUsAnswerStatus.NotAnswered:
        query = query.Where(x => x.Answer == null);
        break;

      default:
        break;
    }
    #endregion

    #region Paging
    await filter.Paging(query.Select(x => new ContactUsDetailsViewModel()
    {
      Id = x.Id,
      Title = x.Title,
      FullName = x.FullName,
      Mobile = x.Mobile,
      Email = x.Email,
      Message = x.Message,
      Answer = x.Answer,
      CreateDate = x.CreateDate,
      UpdateDate = x.UpdateDate,
    }));
    #endregion

    return filter;
  }

  public async Task<ContactUsDetailsViewModel?> GetInfoByIdAsync(int id)
  {
    return await context.ContactUs
        .Select(contactUs => new ContactUsDetailsViewModel()
        {
          Id = contactUs.Id,
          Title = contactUs.Title,
          FullName = contactUs.FullName,
          Mobile = contactUs.Mobile,
          Email = contactUs.Email,
          Message = contactUs.Message,
          Answer = contactUs.Answer,
          CreateDate = contactUs.CreateDate,
          UpdateDate = contactUs.UpdateDate,
        })
        .FirstOrDefaultAsync(contactUs => contactUs.Id == id);
  }

  public async Task AddAsync(ContactUs model)
  {
    await context.ContactUs.AddAsync(model);
  }

  public async Task<ContactUs?> GetByIdAsync(int id)
  {
    return await context.ContactUs
        .FirstOrDefaultAsync(contactUs => contactUs.Id == id);
  }

  public void Update(ContactUs contactUs)
  {
    context.ContactUs.Update(contactUs);
  }

  public async Task SaveChangesAsync()
  {
    await context.SaveChangesAsync();
  }
}
