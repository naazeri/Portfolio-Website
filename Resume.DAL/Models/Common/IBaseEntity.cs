namespace Resume.DAL.Models.Common;

public interface IBaseEntity
{
  public DateTime CreateDate { get; set; }

  public DateTime UpdateDate { get; set; }

}
