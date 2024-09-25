using Microsoft.Extensions.Logging;
using Resume.Bussines.Services.Interfaces;
using Resume.DAL.Models.User;
using Resume.DAL.Repositories.Interfaces;
using Resume.DAL.ViewModels.AboutMe;

namespace Resume.Bussines.Services.Implementations;

public class AboutService(
  IAboutRepository repository,
  IImageService imageService,
  ILogger<AboutService> logger) : IAboutService
{

  public async Task<AdminSideEditAboutViewModel?> GetDetailsForAdminAsync()
  {
    var model = await repository.GetDetailsAsync();

    if (model == null)
    {
      return null;
    }

    return new AdminSideEditAboutViewModel
    {
      Id = model.Id,
      FirstName = model.FirstName,
      LastName = model.LastName,
      MyTitles = model.MyTitles,
      SocialLinks = model.SocialLinks,
      AboutImagePreview = model.AboutImage?.ThumbnailImage,
      Summary = model.Summary,
      CurrentJobTitle = model.CurrentJobTitle,
      CurrentJobTitleDescriptionTop = model.CurrentJobTitleDescriptionTop,
      CurrentJobTitleDescriptionBottom = model.CurrentJobTitleDescriptionBottom,
      Mobile = model.Mobile,
      Email = model.Email,
      BirthDate = model.BirthDate,
      Location = model.Location,
      CreateDate = model.CreateDate,
      UpdateDate = model.UpdateDate,
    };
  }

  public async Task<SiteSideEditAboutViewModel?> GetDetailsForSiteAsync()
  {
    var model = await repository.GetDetailsAsync();

    if (model == null)
    {
      return null;
    }

    return new SiteSideEditAboutViewModel
    {
      Id = model.Id,
      FirstName = model.FirstName,
      LastName = model.LastName,
      MyTitles = model.MyTitles,
      SocialLinks = model.SocialLinks,
      AboutImage = model.AboutImage,
      Summary = model.Summary,
      CurrentJobTitle = model.CurrentJobTitle,
      CurrentJobTitleDescriptionTop = model.CurrentJobTitleDescriptionTop,
      CurrentJobTitleDescriptionBottom = model.CurrentJobTitleDescriptionBottom,
      Mobile = model.Mobile,
      Email = model.Email,
      BirthDate = model.BirthDate,
      Location = model.Location,
      CreateDate = model.CreateDate,
      UpdateDate = model.UpdateDate,
    };
  }

  public async Task<List<SocialLinkDetailsViewModel>> GetSocialLinksAsync()
  {
    var model = await repository.GetSocialLinksAsync();

    if (model == null || model.Count == 0)
    {
      return [];
    }

    List<SocialLinkDetailsViewModel> result = MapSocialLinksToViewModel(model);
    return result;
  }

  public List<SocialLinkDetailsViewModel> MapSocialLinksToViewModel(List<SocialLink> socialLinks)
  {
    List<SocialLinkDetailsViewModel> result = new(socialLinks.Count);
    foreach (var item in socialLinks)
    {
      result.Add(new()
      {
        Id = item.Id,
        Title = item.Title,
        LinkAddress = item.LinkAddress,
        IconName = item.IconName,
        IsActive = item.IsActive,
      });
    }

    return result;
  }

  public async Task<AdminSideEditAboutResult> UpdateAsync(AdminSideEditAboutViewModel model)
  {
    try
    {
      var result = await repository.GetDetailsAsync();
      bool needCreate = false;

      if (result == null)
      {
        needCreate = true;
        result = new About();
      }

      if (model.AboutImage != null)
      {
        // save and compress images
        using var memoryStream = new MemoryStream();
        model.AboutImage.CopyTo(memoryStream);
        var fileBytes = memoryStream.ToArray();
        var (maxPath, largePath, thumbnailPath) = await imageService.CompressAsync(fileBytes, 1680, 400);

        // assign image to result view model
        result.AboutImage = new()
        {
          MaxImage = maxPath,
          LargeImage = largePath,
          ThumbnailImage = thumbnailPath,
          Alt = "profile image"
        };
      }

      result.Id = model.Id;
      result.FirstName = model.FirstName;
      result.LastName = model.LastName;
      result.MyTitles = model.MyTitles;
      result.SocialLinks = model.SocialLinks;
      result.Summary = model.Summary;
      result.CurrentJobTitle = model.CurrentJobTitle;
      result.CurrentJobTitleDescriptionTop = model.CurrentJobTitleDescriptionTop;
      result.CurrentJobTitleDescriptionBottom = model.CurrentJobTitleDescriptionBottom;
      result.Mobile = model.Mobile;
      result.Email = model.Email;
      result.BirthDate = model.BirthDate;
      result.Location = model.Location;
      result.CreateDate = model.CreateDate;
      result.UpdateDate = model.UpdateDate;

      if (needCreate)
      {
        await repository.AddAsync(result);
      }
      else
      {
        repository.Update(result);
      }

      await repository.SaveChangesAsync();

      return AdminSideEditAboutResult.Success;
    }
    catch (Exception e)
    {
      logger.LogError(e, "An error occurred in AboutService->Update");
      return AdminSideEditAboutResult.Error;
    }
  }

}
