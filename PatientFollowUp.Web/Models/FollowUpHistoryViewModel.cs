using System;

namespace PatientFollowUp.Web.Models
{
    public class FollowUpHistoryViewModel
    {
        public DateTime FollowUpDate { get; set; }
        public int StatusID { get; set; }
        public string FollowUpCode { get; set; }
        public bool? NoRelevantFollowUpFound { get; set; }
        public string Comments { get; set; }
        public long? FollowUpExamId { get; set; }
        public int? FollowUpClosedReasonId { get; set; }
        public int? FacilityTypeId { get; set; }
    }
}