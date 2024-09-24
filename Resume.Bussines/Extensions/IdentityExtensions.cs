using System.Security.Claims;
using System.Security.Principal;

namespace Resume.Bussines.Extensions;

public static class IdentityExtensions
{
  public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
  {
    if (claimsPrincipal == null)
    {
      return default;
    }

    if (claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier) == null)
    {
      return default;
    }

    string? userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
    {
      return default;
    }
    else
    {
      return int.Parse(userId);
    }
  }

  public static int GetUserId(this IPrincipal principal)
  {
    if (principal == null)
    {
      return default;
    }

    var user = (ClaimsPrincipal)principal;

    return user.GetUserId();
  }

  public static string GetEmail(this ClaimsPrincipal claimsPrincipal)
  {
    if (claimsPrincipal != null)
    {
      return claimsPrincipal.FindFirst(ClaimTypes.Email)?.Value.ToString() ?? "";
    }

    return "";
  }
}
