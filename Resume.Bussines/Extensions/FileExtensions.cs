using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace Resume.Bussines.Extensions;

public static class FileExtensions
{
  private const int ImageMinimumBytes = 100;

  public static void AddImageToServer(this IFormFile image,
    string fileName, string originalPath, int? width = default, int? height = default,
    string? thumbPath = null, string? deletefileName = null, bool checkImageContent = true)
  {
    if (image == null || !image.IsImage(checkImageContent)) return;
    originalPath = Directory.GetCurrentDirectory() + "/wwwroot" + originalPath;
    thumbPath = Directory.GetCurrentDirectory() + "/wwwroot" + thumbPath;

    if (!Directory.Exists(originalPath))
      Directory.CreateDirectory(originalPath);

    if ((!string.IsNullOrEmpty(deletefileName)) && deletefileName != SiteTools.DefaultImageName)
    {
      if (File.Exists(originalPath + deletefileName))
        File.Delete(originalPath + deletefileName);

      if (!string.IsNullOrEmpty(thumbPath))
      {
        if (File.Exists(thumbPath + deletefileName))
          File.Delete(thumbPath + deletefileName);
      }
    }

    string finalPath = originalPath + fileName;

    using (var stream = new FileStream(finalPath, FileMode.Create))
    {
      if (!Directory.Exists(finalPath)) image.CopyTo(stream);
    }

    if (string.IsNullOrEmpty(thumbPath)) return;
    if (!Directory.Exists(thumbPath))
      Directory.CreateDirectory(thumbPath);

    ImageOptimizer resizer = new();

    if (width != null && height != null)
      resizer.ImageResizer(originalPath + fileName, thumbPath + fileName, width, height);
  }

  public static void AddImageToServerWithOutThumb(this IFormFile image, string fileName, string originalPath,
      int? width,
      int? height, string deletefileName = null, bool checkImageContent = true)
  {
    if (image == null || !image.IsImage(checkImageContent)) return;
    originalPath = Directory.GetCurrentDirectory() + "/wwwroot" + originalPath;

    if (!Directory.Exists(originalPath))
      Directory.CreateDirectory(originalPath);

    if ((!string.IsNullOrEmpty(deletefileName)) && deletefileName != SiteTools.DefaultImageName)
    {
      if (File.Exists(originalPath + deletefileName))
        File.Delete(originalPath + deletefileName);
    }

    string finalPath = originalPath + fileName;

    using var stream = new FileStream(finalPath, FileMode.Create);
    if (!Directory.Exists(finalPath)) image.CopyTo(stream);
  }

  public static void DeleteImage(this string imageName, string originalPath, string? thumbPath)
  {
    if ((string.IsNullOrEmpty(imageName)) || imageName == SiteTools.DefaultImageName) return;
    originalPath = Directory.GetCurrentDirectory() + "/wwwroot" + originalPath;
    thumbPath = Directory.GetCurrentDirectory() + "/wwwroot" + thumbPath;

    if (File.Exists(originalPath + imageName))
      File.Delete(originalPath + imageName);

    if (string.IsNullOrEmpty(thumbPath)) return;
    if (File.Exists(thumbPath + imageName))
      File.Delete(thumbPath + imageName);
  }

  public static void DeleteImage(this string imageName, string originalPath)
  {
    if ((string.IsNullOrEmpty(imageName)) || imageName == SiteTools.DefaultImageName) return;
    originalPath = Directory.GetCurrentDirectory() + "/wwwroot" + originalPath;

    if (File.Exists(originalPath + imageName))
      File.Delete(originalPath + imageName);
  }

  public static List<string> FetchLinksFromSource(this string htmlSource)
  {
    List<string> links = [];

    const string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";

    var matchesImgSrc =
        Regex.Matches(htmlSource, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);

    foreach (Match m in matchesImgSrc)
    {
      string href = m.Groups[1].Value;

      links.Add(href);
    }

    return links;
  }

  public static async Task AddFilesToServer(this IFormFile file, string fileName, string originalPath,
      string deleteFileName = null, bool checkFileExtension = true)
  {
    if ((file != null && file.IsFile(checkFileExtension)))
    {
      originalPath = Directory.GetCurrentDirectory() + "/wwwroot" + originalPath;

      if (!Directory.Exists(originalPath))
        Directory.CreateDirectory(originalPath);

      if (!string.IsNullOrEmpty(deleteFileName))
      {
        if (File.Exists(originalPath + deleteFileName))
        {
          File.Delete(originalPath + deleteFileName);
        }
      }

      if (!Directory.Exists(originalPath))
        Directory.CreateDirectory(originalPath);

      string finalPath = originalPath + fileName;

      await using var stream = new FileStream(finalPath, FileMode.Create);
      await file.CopyToAsync(stream);
    }
  }

  public static void DeleteFile(this string fileName, string originalPath)
  {
    if (string.IsNullOrEmpty(fileName)) return;
    originalPath = Directory.GetCurrentDirectory() + "/wwwroot" + originalPath;

    if (File.Exists(originalPath + fileName))
    {
      File.Delete(originalPath + fileName);
    }
  }

  public static async Task AddFilesToServerWithNoFormatChecker(this IFormFile file, string fileName,
      string originalPath)
  {
    originalPath = Directory.GetCurrentDirectory() + "/wwwroot" + originalPath;

    if (!Directory.Exists(originalPath))
      Directory.CreateDirectory(originalPath);

    string finalPath = originalPath + fileName;

    await using var stream = new FileStream(finalPath, FileMode.Create);
    await file.CopyToAsync(stream);
  }

  public static async Task AddVideoToServer(this IFormFile video, string fileName, string originalPath,
      string deleteFileName = null, bool checkFileExtension = true)
  {
    if (video != null && video.IsVideo())
    {
      originalPath = Directory.GetCurrentDirectory() + "/wwwroot" + originalPath;

      if (!Directory.Exists(originalPath))
        Directory.CreateDirectory(originalPath);

      if (!string.IsNullOrEmpty(deleteFileName))
      {
        if (File.Exists(originalPath + deleteFileName))
        {
          File.Delete(originalPath + deleteFileName);
        }
      }

      if (!Directory.Exists(originalPath))
        Directory.CreateDirectory(originalPath);

      string finalPath = originalPath + fileName;

      await using var stream = new FileStream(finalPath, FileMode.Create);
      await video.CopyToAsync(stream);
    }
  }

  public static bool IsFile(this IFormFile postedFile, bool checkFileExtension = true)
  {
    if (!checkFileExtension) return true;
    return Path.GetExtension(postedFile.FileName)?.ToLower() == ".rar" ||
           Path.GetExtension(postedFile.FileName)?.ToLower() == ".zip" ||
           Path.GetExtension(postedFile.FileName)?.ToLower() == ".pdf";
  }

  public static bool HasLength(this IFormFile postedFile, int length)
  {
    return postedFile.Length <= length;
  }

  public static bool IsImage(this IFormFile postedFile, bool checkImage = true)
  {
    if (!checkImage) return true;
    //-------------------------------------------
    //  Check the image mime types
    //-------------------------------------------
    if (!postedFile.ContentType.Equals("image/jpg", StringComparison.OrdinalIgnoreCase) &&
        !postedFile.ContentType.Equals("image/jpeg", StringComparison.OrdinalIgnoreCase) &&
        !postedFile.ContentType.Equals("image/x-png", StringComparison.OrdinalIgnoreCase) &&
        !postedFile.ContentType.Equals("image/png", StringComparison.OrdinalIgnoreCase) &&
        !postedFile.ContentType.Equals("image/svg+xml", StringComparison.OrdinalIgnoreCase))
    {
      return false;
    }

    //-------------------------------------------
    //  Check the image extension
    //-------------------------------------------
    if (!Path.GetExtension(postedFile.FileName).Equals(".jpg", StringComparison.OrdinalIgnoreCase)
        && !Path.GetExtension(postedFile.FileName).Equals(".png", StringComparison.OrdinalIgnoreCase)
        && !Path.GetExtension(postedFile.FileName).Equals(".jpeg", StringComparison.OrdinalIgnoreCase)
        && !Path.GetExtension(postedFile.FileName).Equals(".svg", StringComparison.OrdinalIgnoreCase))
    {
      return false;
    }

    //-------------------------------------------
    //  Attempt to read the file and check the first bytes
    //-------------------------------------------
    try
    {
      if (!postedFile.OpenReadStream().CanRead)
      {
        return false;
      }

      //------------------------------------------
      //check whether the image size exceeding the limit or not
      //------------------------------------------
      if (postedFile.Length < ImageMinimumBytes)
      {
        return false;
      }

      byte[] buffer = new byte[ImageMinimumBytes];
      postedFile.OpenReadStream().Read(buffer, 0, ImageMinimumBytes);
      string content = System.Text.Encoding.UTF8.GetString(buffer);
      if (Regex.IsMatch(content,
              @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
              RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
      {
        return false;
      }
    }
    catch (Exception)
    {
      return false;
    }

    //-------------------------------------------
    //  Try to instantiate new Bitmap, if .NET will throw exception
    //  we can assume that it's not a valid image
    //-------------------------------------------
    //try
    //{
    //    using (var bitmap = new Bitmap(postedFile.OpenReadStream())) { }
    //}
    //catch (Exception)
    //{
    //    return false;
    //}
    //finally
    //{
    //    postedFile.OpenReadStream().Position = 0;
    //}

    return true;

  }

  public static bool IsVideo(this IFormFile postedFile)
  {
    //-------------------------------------------
    //  Check the video mime types
    //-------------------------------------------
    if (!Path.GetExtension(postedFile.FileName).Equals(".mp4", StringComparison.OrdinalIgnoreCase)
        && !Path.GetExtension(postedFile.FileName).Equals(".avi", StringComparison.OrdinalIgnoreCase)
        && !Path.GetExtension(postedFile.FileName).Equals(".wmv", StringComparison.OrdinalIgnoreCase)
        && !Path.GetExtension(postedFile.FileName).Equals(".mpeg-2", StringComparison.OrdinalIgnoreCase)
        && !Path.GetExtension(postedFile.FileName).Equals(".mov", StringComparison.OrdinalIgnoreCase))
    {
      return false;
    }

    //-------------------------------------------
    //  Check the video extension
    //-------------------------------------------
    if (!Path.GetExtension(postedFile.FileName).Equals(".mp4", StringComparison.OrdinalIgnoreCase)
        && !Path.GetExtension(postedFile.FileName).Equals(".avi", StringComparison.OrdinalIgnoreCase)
        && !Path.GetExtension(postedFile.FileName).Equals(".wmv", StringComparison.OrdinalIgnoreCase)
        && !Path.GetExtension(postedFile.FileName).Equals(".mpeg-2", StringComparison.OrdinalIgnoreCase)
        && !Path.GetExtension(postedFile.FileName).Equals(".mov", StringComparison.OrdinalIgnoreCase))
    {
      return false;
    }

    //-------------------------------------------
    //  Attempt to read the file and check the first bytes
    //-------------------------------------------
    try
    {
      if (!postedFile.OpenReadStream().CanRead)
      {
        return false;
      }
      //------------------------------------------
      //check whether the image size exceeding the limit or not
      //------------------------------------------
      //if (postedFile.Length < ImageMinimumBytes)
      //{
      //    return false;
      //}

      byte[] buffer = new byte[ImageMinimumBytes];
      postedFile.OpenReadStream().Read(buffer, 0, ImageMinimumBytes);
      string content = System.Text.Encoding.UTF8.GetString(buffer);
      if (Regex.IsMatch(content,
              @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
              RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
      {
        return false;
      }
    }
    catch (Exception)
    {
      return false;
    }

    return true;
  }

  public static bool IsSVG(this IFormFile postedFile, bool checkImage = true)
  {
    if (!checkImage) return true;
    //-------------------------------------------
    //  Check the image mime types
    //-------------------------------------------
    if (!postedFile.ContentType.Equals("image/svg+xml", StringComparison.OrdinalIgnoreCase))
    {
      return false;
    }

    //-------------------------------------------
    //  Check the image extension
    //-------------------------------------------
    if (!Path.GetExtension(postedFile.FileName).Equals(".svg", StringComparison.OrdinalIgnoreCase))
    {
      return false;
    }

    //-------------------------------------------
    //  Attempt to read the file and check the first bytes
    //-------------------------------------------
    try
    {
      if (!postedFile.OpenReadStream().CanRead)
      {
        return false;
      }

      //------------------------------------------
      //check whether the image size exceeding the limit or not
      //------------------------------------------
      if (postedFile.Length < ImageMinimumBytes)
      {
        return false;
      }

      byte[] buffer = new byte[ImageMinimumBytes];
      postedFile.OpenReadStream().Read(buffer, 0, ImageMinimumBytes);
      string content = System.Text.Encoding.UTF8.GetString(buffer);
      if (Regex.IsMatch(content,
              @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
              RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
      {
        return false;
      }
    }
    catch (Exception)
    {
      return false;
    }

    return true;

  }
}

public class SiteTools
{

  #region DefaultNames

  public static string DefaultImageName { get; set; }

  #endregion

  #region About me

  public static string AboutMeAvatar { get; set; } = "/Img/AboutMe/";

  #endregion
}


public class ImageOptimizer
{
  public void ImageResizer(string inputImagePath, string outputImagePath, int? width, int? height)
  {
    var customWidth = width ?? 100;

    var customHeight = height ?? 100;

    using (var image = Image.Load(inputImagePath))
    {
      image.Mutate(x => x.Resize(customWidth, customHeight));

      image.Save(outputImagePath, new JpegEncoder
      {
        Quality = 100
      });
    }
  }
}
