using System.Globalization;

namespace Resume.Bussines.Extensions;

public static class StringExtensions
{
  public static string MakeFirstLetterUpper(this string? text)
  {
    if (string.IsNullOrEmpty(text))
    {
      return string.Empty;
    }

    if (text.Length == 1)
    {
      return text.ToUpper(CultureInfo.CurrentCulture);
    }

    return char.ToUpper(text[0], CultureInfo.CurrentCulture) + text[1..];
  }
}
