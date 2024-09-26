using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Resume.Bussines.Services.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;

namespace Resume.Bussines.Services.Implementations;

public class ImageService(
  IHostingEnvironment hostingEnvironment,
  IConfiguration config
) : IImageService
{
  private readonly int defaultLargeWidth = int.Parse(config["Image:LargeWidth"] ?? "1680");
  private readonly int defaultMediumWidth = int.Parse(config["Image:MediumWidth"] ?? "600");
  private readonly int defaultThumbnailWidth = int.Parse(config["Image:ThumbnailWidth"] ?? "200");
  private readonly string IMAGE_DIRECTORY_NAME = config["Image:ImageDirectory"] ?? "images";
  private readonly string MAX_DIRECTORY_NAME = "max";
  private readonly string LARGE_DIRECTORY_NAME = "large";
  private readonly string MEDIUM_DIRECTORY_NAME = "medium";
  private readonly string THUMBNAIL_DIRECTORY_NAME = "thumbnail";

  public async Task<ImageResult> CompressAsync(
    byte[] imageBytes, int? largeWidth = null, int? mediumWidth = null, int? thumbnailWidth = null
  )
  {
    // Create all tasks concurrently
    using var image = Image.Load(imageBytes);
    var maxTask = SaveImageAsync(image, 75, image.Width, MAX_DIRECTORY_NAME);
    var largeTask = SaveImageAsync(image, 75, largeWidth ?? defaultLargeWidth, LARGE_DIRECTORY_NAME);
    var mediumTask = SaveImageAsync(image, 75, mediumWidth ?? defaultMediumWidth, MEDIUM_DIRECTORY_NAME);
    var thumbnailTask = SaveImageAsync(image, 50, thumbnailWidth ?? defaultThumbnailWidth, THUMBNAIL_DIRECTORY_NAME);

    // Wait for all tasks to complete
    var results = await Task.WhenAll(maxTask, largeTask, mediumTask, thumbnailTask);
    var imageResult = new ImageResult
    (
      MaxImage: results[0],
      LargeImage: results[1],
      MediumImage: results[2],
      ThumbnailImage: results[3]
    );

    return imageResult;
  }

  public async Task<ImageResult> CompressAsync(
    string uploadPath, int? largeWidth = null, int? mediumWidth = null, int? thumbnailWidth = null
  )
  {
    using var image = await Image.LoadAsync(uploadPath);

    // Create all tasks concurrently
    var maxTask = SaveImageAsync(image, 75, image.Width, MAX_DIRECTORY_NAME);
    var largeTask = SaveImageAsync(image, 75, largeWidth ?? defaultLargeWidth, LARGE_DIRECTORY_NAME);
    var mediumTask = SaveImageAsync(image, 75, mediumWidth ?? defaultMediumWidth, MEDIUM_DIRECTORY_NAME);
    var thumbnailTask = SaveImageAsync(image, 50, thumbnailWidth ?? defaultThumbnailWidth, THUMBNAIL_DIRECTORY_NAME);

    // Wait for all tasks to complete
    var results = await Task.WhenAll(maxTask, largeTask, mediumTask, thumbnailTask);
    var imageResult = new ImageResult
    (
      MaxImage: results[0],
      LargeImage: results[1],
      MediumImage: results[2],
      ThumbnailImage: results[3]
    );

    return imageResult;
  }

  private async Task<string> SaveImageAsync(Image image, int quality, int width, string subDirName)
  {
    if (width > 0 && image.Width > width)
    {
      var aspectRatio = (double)image.Height / image.Width;
      image.Mutate(i => i.Resize(width, (int)(width * aspectRatio)));
    }

    var now = DateTime.Now;
    var reletivePath = Path.Combine(IMAGE_DIRECTORY_NAME, now.Year.ToString(), now.Month.ToString(), subDirName);
    var saveFullPath = Path.Combine(hostingEnvironment.WebRootPath, reletivePath);
    var imageName = $"{Guid.NewGuid()}.webp";

    if (!Directory.Exists(saveFullPath))
    {
      Directory.CreateDirectory(saveFullPath);
    }

    await image.SaveAsWebpAsync(Path.Combine(saveFullPath, imageName), new WebpEncoder { Quality = quality });
    return $"/{reletivePath.Replace("\\", "/")}/{imageName}";
  }

}

public record ImageResult(string MaxImage, string LargeImage, string MediumImage, string ThumbnailImage);
