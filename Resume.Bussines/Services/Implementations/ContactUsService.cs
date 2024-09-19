using Resume.Bussines.Services.Interfaces;
using Resume.DAL.Models;
using Resume.DAL.Repositories.Interfaces;
using Resume.DAL.ViewModels.ContactUs;

namespace Resume.Bussines.Services.Implementations;

public class ContactUsService(
  IContactUsRepository contactUsRepository
  // IViewRenderService viewRenderService,
  // IEmailService emailService
  ) : IContactUsService
{

  #region Methods

  public async Task<FilterContactUsViewModel> GetAllAsync(FilterContactUsViewModel filter)
  {
    return await contactUsRepository.GetAllAsync(filter);
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

    await contactUsRepository.AddAsync(model);
    await contactUsRepository.SaveChangesAsync();

    return CreateContactUsResult.Success;
  }

  public async Task<ContactUsDetailsViewModel?> GetByIdAsync(int id)
  {
    return await contactUsRepository.GetInfoByIdAsync(id);
  }

  public async Task<AnswerResult> AnswerAsync(ContactUsDetailsViewModel model)
  {
    var contactUs = await contactUsRepository.GetByIdAsync(model.Id);

    if (contactUs == null)
      return AnswerResult.ContactUsNotFound;

    if (string.IsNullOrEmpty(model.Answer))
      return AnswerResult.AnswerIsNull;

    contactUs.Answer = model.Answer;

    contactUsRepository.Update(contactUs);
    await contactUsRepository.SaveChangesAsync();

    #region Send Email
    // string body = await viewRenderService.RenderToStringAsync("Emails/AnswerContactUs", model);
    // await emailService.SendEmail(contactUs.Email, "پاسخ به تماس با ما", body);
    #endregion

    return AnswerResult.Success;
  }

  #endregion

}
