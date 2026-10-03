using System;

namespace MunicipalServicesApp
{
    public class MunicipalEvent
    {
        public int EventID { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; } // 1 = Urgent, 2 = Normal, 3 = Low
    }
}