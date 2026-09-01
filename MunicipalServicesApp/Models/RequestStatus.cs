namespace MunicipalServicesApp.Models
{
    public enum RequestStatus
    {
        Submitted,
        UnderReview,
        InProgress,
        Resolved,
        Rejected
    }

    public static class RequestStatusExtensions
    {
        public static string ToDisplayString(this RequestStatus status)
        {
            switch (status)
            {
                case RequestStatus.Submitted: return "Submitted";
                case RequestStatus.UnderReview: return "Under Review";
                case RequestStatus.InProgress: return "In Progress";
                case RequestStatus.Resolved: return "Resolved";
                case RequestStatus.Rejected: return "Rejected";
                default: return status.ToString();
            }
        }
    }
}
