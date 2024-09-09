using System.Globalization;

namespace Resume.Bussines.Extensions;

public static class DateExtensions
{
  public static string ToShamsi(this DateTime date)
  {
    PersianCalendar pc = new();

    int year = pc.GetYear(date);
    int month = pc.GetMonth(date);
    int day = pc.GetDayOfMonth(date);

    return $"{year}/{month.ToString("00")}/{day.ToString("00")}";
  }
}
