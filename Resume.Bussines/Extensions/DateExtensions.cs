using System.Globalization;

namespace Resume.Bussines.Extensions;

public static class DateExtensions
{
  public static string ToShamsi(this DateTime date)
  {
    if (date == null || date == DateTime.MinValue)
    {
      return string.Empty;
    }

    return ConvertToShamsi(date);
  }

  public static string ToShamsi(this DateOnly date)
  {
    if (date == null || date == DateOnly.MinValue)
    {
      return string.Empty;
    }

    DateTime dateTime = date.ToDateTime(new TimeOnly());
    return ConvertToShamsi(dateTime);
  }

  private static string ConvertToShamsi(DateTime date)
  {
    PersianCalendar pc = new();
    int year = pc.GetYear(date);
    int month = pc.GetMonth(date);
    int day = pc.GetDayOfMonth(date);

    return $"{year}/{month:00}/{day:00}";
  }

}
