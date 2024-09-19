using Resume.Bussines.Services.Interfaces;
using Resume.DAL.Models;
using Resume.DAL.Repositories.Interfaces;
using Resume.DAL.ViewModels.ContactUs;

namespace Resume.Bussines.Services.Implementations;

public class ContactUsService(IContactUsRepository contactUsRepository) : IContactUsService
{

  #region Methods
  public async Task<CreateContactUsResult> AddAsync(CreateContactUsViewModel viewModel)
  {
    var model = new ContactUs()
    {
      Answer = null,
      Mobile = viewModel.Mobile,
      Email = viewModel.Email,
      FullName = viewModel.FullName,
      Message = viewModel.Message,
    };

    await contactUsRepository.AddAsync(model);
    await contactUsRepository.SaveChangesAsync();

    return CreateContactUsResult.Success;
  }

  #endregion

}
