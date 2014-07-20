using System;
using System.Collections.Generic;

namespace PatientFollowUp.Web.Models
{
    public class SaveFollowUpUpdatesInputModel
    {
        public int FollowUpId { get; set; }
        public List<Int64> FollowUpExamIds { get; set; }
        public bool NoRelevantFollowupFound { get; set; }
        public string Comments { get; set; }
    }
}