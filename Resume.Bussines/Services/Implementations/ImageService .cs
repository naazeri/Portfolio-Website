using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Resume.Bussines.Services.Interfaces;
using Resume.DAL.Models.Config;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;

namespace Resume.Bussines.Services.Implementations;

public class ImageService(
  IHostingEnvironment hostingEnvironment,
  IOptions<ImageConfiguration> imageConfig
) : IImageService
{
  // private readonly int DEFAULT_WIDTH_LARGE = int.Parse(config["Image:Width:Large"] ?? "1680");
  // private readonly int DEFAULT_WIDTH_MEDIUM = int.Parse(config["Image:Width:Medium"] ?? "600");
  // private readonly int DEFAULT_WIDTH_THUMBNAIL = int.Parse(config["Image:Width:Thumbnail"] ?? "200");
  // private readonly string IMAGE_DIRECTORY_NAME = config["Image:ImageDirectory"] ?? "images";
  // private readonly int DEFAULT_QUALITY_MAX = int.Parse(config["Image:Quality:Max"] ?? "75");
  // private readonly int DEFAULT_QUALITY_LARGE = int.Parse(config["Image:Quality:Large"] ?? "75");
  // private readonly int DEFAULT_QUALITY_MEDIUM = int.Parse(config["Image:Quality:Medium"] ?? "75");
  // private readonly int DEFAULT_QUALITY_THUMBNAIL = int.Parse(config["Image:Quality:Thumbnail"] ?? "70");
  // private readonly string MAX_DIRECTORY_NAME = "max";
  // private readonly string LARGE_DIRECTORY_NAME = "large";
  // private readonly string MEDIUM_DIRECTORY_NAME = "medium";
  // private readonly string THUMBNAIL_DIRECTORY_NAME = "thumbnail";

  public async Task<ImageResult> CompressAsync(
    byte[] imageBytes, int? largeWidth = null, int? mediumWidth = null, int? thumbnailWidth = null
  )
  {
    using var image = Image.Load(imageBytes);
    return await CompressAndSaveAsync(image, largeWidth, mediumWidth, thumbnailWidth);
  }

  public async Task<ImageResult> CompressAsync(
    string uploadPath, int? largeWidth = null, int? mediumWidth = null, int? thumbnailWidth = null
  )
  {
    using var image = await Image.LoadAsync(uploadPath);
    return await CompressAndSaveAsync(image, largeWidth, mediumWidth, thumbnailWidth);
  }

  private async Task<ImageResult> CompressAndSaveAsync(Image image, int? largeWidth = null, int? mediumWidth = null, int? thumbnailWidth = null)
  {
    // Create all tasks concurrently
    var maxTask = SaveImageAsync(image, imageConfig.Value.Quality.Max, image.Width, imageConfig.Value.Directory.Max);
    var largeTask = SaveImageAsync(image, imageConfig.Value.Quality.Large, largeWidth ?? imageConfig.Value.DefaultWidth.Large, imageConfig.Value.Directory.Large);
    var mediumTask = SaveImageAsync(image, imageConfig.Value.Quality.Medium, mediumWidth ?? imageConfig.Value.DefaultWidth.Medium, imageConfig.Value.Directory.Medium);
    var thumbnailTask = SaveImageAsync(image, imageConfig.Value.Quality.Thumbnail, thumbnailWidth ?? imageConfig.Value.DefaultWidth.Thumbnail, imageConfig.Value.Directory.Thumbnail);

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
    var reletivePath = Path.Combine(
      imageConfig.Value.Directory.Root,
      now.Year.ToString(),
      now.Month.ToString(),
      subDirName
    );
    var saveFullPath = Path.Combine(hostingEnvironment.WebRootPath, reletivePath);
    var imageName = $"{Guid.NewGuid()}.webp";

    if (!Directory.Exists(saveFullPath))
    {
      Directory.CreateDirectory(saveFullPath);
    }

    await image.SaveAsWebpAsync(
      Path.Combine(saveFullPath, imageName),
      new WebpEncoder { Quality = quality }
    );

    return $"/{reletivePath.Replace("\\", "/")}/{imageName}";
  }

}

public record ImageResult(string MaxImage, string LargeImage, string MediumImage, string ThumbnailImage);
