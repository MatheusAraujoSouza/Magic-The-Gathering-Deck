using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserAuthApi.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        private string PasswordHash { get; set; }

        public User(string username, string password)
        {
            Username = username;
            PasswordHash = HashPassword(password);
        }

        public bool VerifyPassword(string password)
        {
            string passwordHash = HashPassword(password);
            return PasswordHash.Equals(passwordHash);
        }

        private string HashPassword(string password)
        {
            string hashedPassword = "admin123";
            return hashedPassword;
        }
    }
}
