using Microsoft.EntityFrameworkCore;

namespace Resume.DAL.ViewModels.Common;

public class BasePaging<T>
{
  public BasePaging()
  {
    Page = 1;
    TakeEntity = 10;
    HowManyPagesShowBeforeAndAfterCurrentPage = 3;
    Entities = [];
  }

  #region Properties
  public int Page { get; set; }
  public int PageCount { get; set; }
  public int AllEntitesCount { get; set; }
  public int StartPage { get; set; }
  public int EndPage { get; set; }
  public int TakeEntity { get; set; }
  public int SkipEntity { get; set; }
  public int HowManyPagesShowBeforeAndAfterCurrentPage { get; set; }
  public List<T> Entities { get; set; }
  #endregion

  #region Methods
  public PagingViewModel GetCurrentPaging()
  {
    return new()
    {
      Page = Page,
      StartPage = StartPage,
      EndPage = EndPage,
      PageCount = PageCount
    };
  }

  public async Task<BasePaging<T>> Paging(IQueryable<T> query)
  {
    AllEntitesCount = await query.CountAsync();
    PageCount = (int)Math.Ceiling(AllEntitesCount / (double)TakeEntity);
    try
    {
      Page = Math.Clamp(Page, 1, PageCount);
    }
    catch (Exception)
    {
      Page = 1;
    }
    StartPage = Math.Max(1, Page - HowManyPagesShowBeforeAndAfterCurrentPage);
    EndPage = Math.Min(PageCount, Page + HowManyPagesShowBeforeAndAfterCurrentPage);
    SkipEntity = (Page - 1) * TakeEntity;
    Entities = await query.Skip(SkipEntity).Take(TakeEntity).ToListAsync();

    return this;
  }

  public BasePaging<T> Paging()
  {
    AllEntitesCount = Entities.Count;
    PageCount = (int)Math.Ceiling(AllEntitesCount / (double)TakeEntity);
    Page = Math.Clamp(Page, 1, PageCount);
    StartPage = Math.Max(1, Page - HowManyPagesShowBeforeAndAfterCurrentPage);
    EndPage = Math.Min(PageCount, Page + HowManyPagesShowBeforeAndAfterCurrentPage);
    SkipEntity = (Page - 1) * TakeEntity;

    return this;
  }

  #endregion
}

public class PagingViewModel
{
  public int Page { get; set; }
  public int StartPage { get; set; }
  public int EndPage { get; set; }
  public int PageCount { get; set; }

}