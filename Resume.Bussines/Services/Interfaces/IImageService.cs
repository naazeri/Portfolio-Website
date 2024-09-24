namespace Resume.Bussines.Services.Interfaces;

public interface IImageService
{
  Task<(string maxPath, string largePath, string thumbnailPath)> CompressAsync(byte[] imageBytes, int largeWidth, int thumbnailWidth);
  Task<(string maxPath, string largePath, string thumbnailPath)> CompressAsync(string uploadPath, int largeWidth, int thumbnailWidth);
}
