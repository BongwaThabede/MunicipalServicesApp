using System.Collections.Generic;
using System.Linq;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Data
{
    /// <summary>
    /// Shared in-memory store for reported issues. A List&lt;ServiceRequest&gt; is
    /// used because issues need to be appended in submission order and iterated
    /// sequentially both for a single resident's history and for the municipal
    /// dashboard's full list.
    /// </summary>
    public static class IssueRepository
    {
        private static readonly List<ServiceRequest> _issues = new List<ServiceRequest>();
        private static int _nextId = 1;

        public static ServiceRequest Add(string residentUsername, string location, string category, string description, List<string> attachments)
        {
            var request = new ServiceRequest
            {
                Id = _nextId++,
                ResidentUsername = residentUsername,
                Location = location,
                Category = category,
                Description = description,
                AttachmentPaths = attachments ?? new List<string>()
            };

            request.History.Add(new StatusUpdate(RequestStatus.Submitted, "Report received by the municipality.", "System"));
            _issues.Add(request);
            return request;
        }

        public static IReadOnlyList<ServiceRequest> All => _issues.AsReadOnly();

        public static IReadOnlyList<ServiceRequest> ForResident(string username) =>
            _issues.Where(i => string.Equals(i.ResidentUsername, username, System.StringComparison.OrdinalIgnoreCase))
                   .OrderByDescending(i => i.DateReported)
                   .ToList();

        public static ServiceRequest GetById(int id) => _issues.FirstOrDefault(i => i.Id == id);

        public static void UpdateStatus(int id, RequestStatus newStatus, string message, string updatedBy)
        {
            var request = GetById(id);
            if (request == null) return;

            request.Status = newStatus;
            request.History.Add(new StatusUpdate(newStatus, message, updatedBy));
        }

        public static int Count => _issues.Count;
    }
}
