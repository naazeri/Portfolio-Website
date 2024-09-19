using Resume.DAL.ViewModels.ContactUs;

namespace Resume.Bussines.Services.Interfaces;

public interface IContactUsService
{
  #region Methods

  Task<CreateContactUsResult> AddAsync(CreateContactUsViewModel viewModel);
  Task<FilterContactUsViewModel> GetAllAsync(FilterContactUsViewModel viewModel);
  Task<ContactUsDetailsViewModel?> GetByIdAsync(int id);
  Task<AnswerResult> AnswerAsync(ContactUsDetailsViewModel model);

  #endregion
}
