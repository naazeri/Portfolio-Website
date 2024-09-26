using Resume.Bussines.Services.Implementations;

namespace Resume.Bussines.Services.Interfaces;

public interface IImageService
{
  Task<ImageResult> CompressAsync(byte[] imageBytes, int? largeWidth = null, int? mediumWidth = null, int? thumbnailWidth = null);
  Task<ImageResult> CompressAsync(string uploadPath, int? largeWidth = null, int? mediumWidth = null, int? thumbnailWidth = null);
}
