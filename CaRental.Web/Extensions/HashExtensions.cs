using System.Security.Cryptography;
using System.Text;

namespace CaRental.Web.Extensions
{
    public static class HashExtensions
    {
        /// <summary>
        /// Take string and converts it to sha256 hash
        /// This code is taken from: https://www.c-sharpcorner.com/article/compute-sha256-hash-in-c-sharp/
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ConvertToSha256Hash(this string input)
        {
            using var sha256Hash = SHA256.Create();
            var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var stringBuilder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
                stringBuilder.Append(bytes[i].ToString("x2"));

            return stringBuilder.ToString();
        }
    }
}
