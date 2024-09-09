using System.ComponentModel.DataAnnotations;

namespace Resume.DAL.Models.Common;

public class BaseEntity<T>
{
  [Key]
  public T Id { get; set; }

  public DateTime CreateDate { get; set; }

  public DateTime UpdateDate { get; set; }

}