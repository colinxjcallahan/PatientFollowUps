//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PatientFollowUp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class FollowUpHistory
    {
        public int FollowUpHistoryId { get; set; }
        public int FollowUpID { get; set; }
        public string PatientMRN { get; set; }
        public string ReferrerID { get; set; }
        public long AccessionNumber { get; set; }
        public string ExamType { get; set; }
        public System.DateTime FollowUpDate { get; set; }
        public int StatusID { get; set; }
        public string FollowUpCode { get; set; }
        public Nullable<bool> NoRelevantFollowUpFound { get; set; }
        public string Comments { get; set; }
        public Nullable<long> FollowUpExamId { get; set; }
        public Nullable<int> FollowUpClosedReasonId { get; set; }
        public Nullable<int> FacilityTypeId { get; set; }
        public Nullable<System.DateTime> OriginalFollowUpDate { get; set; }
    
        public virtual FacilityType FacilityType { get; set; }
        public virtual FollowUp FollowUp { get; set; }
    }
}
