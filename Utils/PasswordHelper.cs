using System;
using System.Security.Cryptography;
using System.Text;

namespace TechnoAcademyApi.Utils
{
    public class PasswordHelper
    {
        public static string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
        public static string DecryptPassword(string encryptedPassword)
        {
            byte[] hash = Convert.FromBase64String(encryptedPassword);
            return Encoding.UTF8.GetString(hash);
        }
    }
}