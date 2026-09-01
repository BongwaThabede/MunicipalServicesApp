using System;

namespace MunicipalServicesApp.Models
{
    /// <summary>
    /// One entry in a service request's timeline — either the automatic
    /// "Submitted" entry created on capture, or a status change with
    /// feedback message added later by a municipal staff member.
    /// </summary>
    public class StatusUpdate
    {
        public DateTime Timestamp { get; set; }
        public RequestStatus Status { get; set; }
        public string Message { get; set; }
        public string UpdatedBy { get; set; }

        public StatusUpdate(RequestStatus status, string message, string updatedBy)
        {
            Timestamp = DateTime.Now;
            Status = status;
            Message = message;
            UpdatedBy = updatedBy;
        }
    }
}
