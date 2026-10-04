using MunicipalServicesApp.Models;

namespace MunicipalServicesApp
{
    /// <summary>
    /// Holds the current logged-in user's information.
    /// </summary>
    public static class UserSession
    {
        // The currently logged-in account (null when no user is logged in)
        public static UserAccount CurrentUser { get; set; }

        // Friendly display name for UI
        public static string FriendlyName => CurrentUser?.FullName ?? "Resident";

        // Role derived from CurrentUser (string for compatibility with existing checks)
        public static string Role => CurrentUser != null && CurrentUser.Role == UserRole.Municipal ? "Staff" : "Resident";

        public static void LogOut()
        {
            CurrentUser = null;
        }
    }
}
