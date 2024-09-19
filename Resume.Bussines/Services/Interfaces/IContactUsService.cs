using Resume.DAL.ViewModels.ContactUs;

namespace Resume.Bussines.Services.Interfaces;

public interface IContactUsService
{
  #region Methods

  Task<CreateContactUsResult> AddAsync(CreateContactUsViewModel viewModel);

  #endregion
}
