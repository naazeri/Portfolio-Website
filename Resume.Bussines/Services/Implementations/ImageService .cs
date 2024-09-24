using Microsoft.AspNetCore.Hosting;
using Resume.Bussines.Services.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;

namespace Resume.Bussines.Services.Implementations;

public class ImageService(IHostingEnvironment hostingEnvironment) : IImageService
{
  private readonly string IMAGE_DIRECTORY = "images";

  public async Task<(string maxPath, string largePath, string thumbnailPath)> CompressAsync(byte[] imageBytes, int largeWidth, int thumbnailWidth)
  {
    // Create all tasks concurrently
    using var image = Image.Load(imageBytes);
    var maxPath = SaveImageAsync(image, 75, image.Width, "max");
    var largePath = SaveImageAsync(image, 75, largeWidth, "large");
    var thumbnailPath = SaveImageAsync(image, 50, thumbnailWidth, "thumbnail");

    // Wait for all tasks to complete
    var results = await Task.WhenAll(maxPath, largePath, thumbnailPath);

    return (results[0], results[1], results[2]);
  }

  public async Task<(string maxPath, string largePath, string thumbnailPath)> CompressAsync(string uploadPath, int largeWidth, int thumbnailWidth)
  {
    using var image = await Image.LoadAsync(uploadPath);

    // Create all tasks concurrently
    var maxTask = SaveImageAsync(image, 75, image.Width, "max");
    var largeTask = SaveImageAsync(image, 75, largeWidth, "large");
    var thumbnailTask = SaveImageAsync(image, 50, thumbnailWidth, "thumbnail");

    // Wait for all tasks to complete
    var results = await Task.WhenAll(maxTask, largeTask, thumbnailTask);

    return (results[0], results[1], results[2]);
  }

  private async Task<string> SaveImageAsync(Image image, int quality, int width, string subDirName)
  {
    if (width > 0 && image.Width > width)
    {
      var aspectRatio = (double)image.Height / image.Width;
      image.Mutate(i => i.Resize(width, (int)(width * aspectRatio)));
    }

    var now = DateTime.Now;
    var reletivePath = Path.Combine(IMAGE_DIRECTORY, now.Year.ToString(), now.Month.ToString(), subDirName);
    var saveFullPath = Path.Combine(hostingEnvironment.WebRootPath, reletivePath);
    var imageName = $"{Guid.NewGuid().ToString()}.webp";

    if (!Directory.Exists(saveFullPath))
    {
      Directory.CreateDirectory(saveFullPath);
    }

    await image.SaveAsWebpAsync(Path.Combine(saveFullPath, imageName), new WebpEncoder { Quality = quality });
    return $"/{reletivePath.Replace("\\", "/")}/{imageName}";
  }

}
