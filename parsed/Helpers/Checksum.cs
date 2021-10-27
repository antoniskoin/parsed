using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;

namespace parsed.Helpers
{
    public static class Checksum
    {
        public static string HashMd5(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return null;

            using var md5 = MD5.Create();
            return string.Join("", md5.ComputeHash(bytes).Select(x => x.ToString("X2")));
        }
        
        public static string HashSha256(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return null;

            using var sha256 = SHA256.Create();
            return string.Join("", sha256.ComputeHash(bytes).Select(x => x.ToString("X2")));
        }
        
        public static byte[] GetBytes(IFormFile formFile)
        {
            using var memoryStream = new MemoryStream();
            formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}