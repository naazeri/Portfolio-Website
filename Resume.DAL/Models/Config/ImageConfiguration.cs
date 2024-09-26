namespace Resume.DAL.Models.Config;

public record ImageConfiguration
{
  public const string SectionName = "Image"; // This will be used to bind to the "Image" section in the JSON

  public ImageSizeConfiguration DefaultWidth { get; set; } = new ImageSizeConfiguration();
  public ImageQualityConfiguration Quality { get; set; } = new ImageQualityConfiguration();
  public ImageDirectoryConfiguration Directory { get; set; } = new ImageDirectoryConfiguration();
}

public record ImageSizeConfiguration
{
  public int Large { get; set; } = 1680;
  public int Medium { get; set; } = 600;
  public int Thumbnail { get; set; } = 200;
}

public record ImageQualityConfiguration
{
  public int Max { get; set; } = 75;
  public int Large { get; set; } = 75;
  public int Medium { get; set; } = 75;
  public int Thumbnail { get; set; } = 70;
}

public record ImageDirectoryConfiguration
{
  public string Root { get; set; } = "uploads/images";
  public bool CategoriesWithDate { get; set; } = true;
  public string Max { get; set; } = "max";
  public string Large { get; set; } = "large";
  public string Medium { get; set; } = "medium";
  public string Thumbnail { get; set; } = "thumbnail";
}
