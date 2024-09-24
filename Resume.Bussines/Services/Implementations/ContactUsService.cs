using Resume.Bussines.Services.Interfaces;
using Resume.DAL.Models;
using Resume.DAL.Repositories.Interfaces;
using Resume.DAL.ViewModels.ContactUs;

namespace Resume.Bussines.Services.Implementations;

public class ContactUsService(
  IContactUsRepository repository,
  IViewRenderService viewRenderService,
  IEmailService emailService
  ) : IContactUsService
{

  #region Methods

  public async Task<FilterContactUsViewModel> GetAllAsync(FilterContactUsViewModel filter)
  {
    return await repository.GetAllAsync(filter);
  }

  public async Task<ContactUs?> GetByIdAsync(int id)
  {
    return await repository.GetByIdAsync(id);
  }

  public async Task<ContactUsDetailsViewModel?> GetInfoByIdAsync(int id)
  {
    var contactUs = await repository.GetByIdAsync(id);
    if (contactUs == null)
    {
      return null;
    }

    return new ContactUsDetailsViewModel
    {
      Id = contactUs.Id,
      Title = contactUs.Title,
      FullName = contactUs.FullName,
      Mobile = contactUs.Mobile,
      Email = contactUs.Email,
      Message = contactUs.Message,
      Answer = contactUs.Answer,
      CreateDate = contactUs.CreateDate,
      UpdateDate = contactUs.UpdateDate
    };
  }

  public async Task<CreateContactUsResult> AddAsync(CreateContactUsViewModel viewModel)
  {
    var model = new ContactUs()
    {
      Title = viewModel.Title,
      Mobile = viewModel.Mobile,
      Email = viewModel.Email,
      FullName = viewModel.FullName,
      Message = viewModel.Message,
      Answer = null,
    };

    await repository.AddAsync(model);
    await repository.SaveChangesAsync();

    return CreateContactUsResult.Success;
  }

  public async Task<AnswerResult> AnswerAsync(ContactUsDetailsViewModel model)
  {
    var contactUs = await repository.GetByIdAsync(model.Id);

    if (contactUs == null)
    {
      return AnswerResult.ContactUsNotFound;
    }

    if (string.IsNullOrEmpty(model.Answer))
    {
      return AnswerResult.AnswerIsNull;
    }

    contactUs.Answer = model.Answer;

    repository.Update(contactUs);
    await repository.SaveChangesAsync();

    #region Send Email
    // string body = await viewRenderService.RenderToStringAsync("Emails/AnswerContactUs", model);
    // emailService.SendEmail(contactUs.Email, "پاسخ به تماس با ما", body);
    #endregion

    return AnswerResult.Success;
  }

  #endregion

}
