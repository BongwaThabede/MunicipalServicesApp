using MunicipalServicesApp.Models;

namespace MunicipalServicesApp
{
    /// <summary>
    /// Holds the currently logged-in account for the lifetime of the running
    /// application, so forms can tell who's using them without passing the
    /// account around everywhere.
    /// </summary>
    public static class UserSession
    {
        public static UserAccount CurrentUser { get; set; }

        public static bool IsLoggedIn => CurrentUser != null;

        public static string FriendlyName =>
            CurrentUser == null || string.IsNullOrWhiteSpace(CurrentUser.FullName)
                ? "there"
                : CurrentUser.FullName.Trim();

        public static void LogOut() => CurrentUser = null;
    }
}
