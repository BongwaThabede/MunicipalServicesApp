namespace MunicipalServicesApp.Models
{
    public enum UserRole
    {
        Resident,
        Municipal
    }

    /// <summary>
    /// A registered account. Passwords are never stored in plain text —
    /// only a salted SHA-256 hash (see Data.UserRepository).
    /// </summary>
    public class UserAccount
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public UserRole Role { get; set; }
    }
}
