using BCrypt.Net;
using System.Data;
namespace FiscalFriendsBusiness
{
    public class SecurityHelper
    {
        public static String generatePasswordHash(String password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);
        }

        public static bool VerifyPassword(String password, string passwordHash) 
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
        }

        public static String GetDBConnectionString()
        {
            string conString = "Server = (localdb)\\MSSQLLocalDB;Database=FiscalFriends;Trusted_Connection=true";
            return conString;

        }
    }
}
