using System;
using System.Collections.Generic;

namespace MunicipalServicesApp.Models
{
    /// <summary>
    /// Represents a single issue/service request reported by a resident,
    /// including who reported it and the full history of status changes
    /// and feedback messages added by municipal staff.
    /// </summary>
    public class ServiceRequest
    {
        public int Id { get; set; }
        public string ResidentUsername { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public List<string> AttachmentPaths { get; set; }
        public DateTime DateReported { get; set; }
        public RequestStatus Status { get; set; }
        public List<StatusUpdate> History { get; set; }

        public ServiceRequest()
        {
            AttachmentPaths = new List<string>();
            History = new List<StatusUpdate>();
            DateReported = DateTime.Now;
            Status = RequestStatus.Submitted;
        }

        /// <summary>The most recent feedback message, if any staff member has left one.</summary>
        public string LatestFeedback
        {
            get
            {
                for (int i = History.Count - 1; i >= 0; i--)
                {
                    if (!string.IsNullOrWhiteSpace(History[i].Message))
                        return History[i].Message;
                }
                return string.Empty;
            }
        }

        public override string ToString()
        {
            return $"[#{Id}] {Category} @ {Location} — {Status.ToDisplayString()}";
        }
    }
}
