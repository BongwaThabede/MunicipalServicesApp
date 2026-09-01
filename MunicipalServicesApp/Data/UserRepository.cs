using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Data
{
    /// <summary>
    /// In-memory account store. A single demo municipal staff account is
    /// seeded on startup (see README for the credentials) so the "municipality
    /// logs in and changes status" workflow can be demonstrated without a
    /// separate admin-provisioning process. Resident accounts are created
    /// through the Register screen.
    /// </summary>
    public static class UserRepository
    {
        private static readonly List<UserAccount> _users = new List<UserAccount>();

        static UserRepository()
        {
            // Seed one municipal staff account for demonstration/marking purposes.
            CreateAccount("municipality", "Municipal Staff", "Municipal@123", UserRole.Municipal);
        }

        public static UserAccount Register(string username, string fullName, string password, out string error)
        {
            error = string.Empty;
            username = (username ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(password))
            {
                error = "Please fill in every field.";
                return null;
            }

            if (password.Length < 6)
            {
                error = "Password must be at least 6 characters long.";
                return null;
            }

            if (_users.Any(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase)))
            {
                error = "That username is already taken. Please choose another.";
                return null;
            }

            return CreateAccount(username, fullName, password, UserRole.Resident);
        }

        public static UserAccount ValidateLogin(string username, string password)
        {
            var user = _users.FirstOrDefault(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase));
            if (user == null) return null;

            var candidateHash = Hash(password, user.PasswordSalt);
            return candidateHash == user.PasswordHash ? user : null;
        }

        private static UserAccount CreateAccount(string username, string fullName, string password, UserRole role)
        {
            var salt = GenerateSalt();
            var account = new UserAccount
            {
                Username = username,
                FullName = fullName,
                PasswordSalt = salt,
                PasswordHash = Hash(password, salt),
                Role = role
            };
            _users.Add(account);
            return account;
        }

        private static string GenerateSalt()
        {
            var bytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }
            return Convert.ToBase64String(bytes);
        }

        private static string Hash(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var combined = Encoding.UTF8.GetBytes(salt + password);
                var hashBytes = sha256.ComputeHash(combined);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
