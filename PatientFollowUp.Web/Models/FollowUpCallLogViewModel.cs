using System;

namespace PatientFollowUp.Web.Models
{
    public class FollowUpCallLogViewModel
    {
        public int FollowUpCallLogId { get; set; }
        public string FollowUpCallLogText { get; set; }
        public int? FollowUpCallLogTypeId { get; set; }
        public int FollowUpId { get; set; }
        public DateTime FollowUpCallLogDate { get; set; }
    }
}