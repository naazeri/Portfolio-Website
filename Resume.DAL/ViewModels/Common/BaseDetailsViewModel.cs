namespace Resume.DAL.ViewModels.Common;

public class BaseDetailsViewModel<T>
{
  public T Id { get; set; }
  public DateTime CreateDate { get; set; }
  public DateTime UpdateDate { get; set; }
}
