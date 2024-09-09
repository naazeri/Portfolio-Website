using System.Security.Cryptography;
using System.Text;

namespace Resume.Bussines.Security;

public static class PasswordHasher
{
  //Encrypt using MD5
  public static string EncodePasswordMd5(this string password)
  {
    byte[] originalBytes = Encoding.Default.GetBytes(password);
    byte[] encodedBytes = MD5.HashData(originalBytes);

    return BitConverter.ToString(encodedBytes);
  }
}
