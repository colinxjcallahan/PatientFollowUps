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
    
    public partial class FollowUpWithSynonymData
    {
        public int FollowUpID { get; set; }
        public string PatientMRN { get; set; }
        public long AccessionNumber { get; set; }
        public string ExamType { get; set; }
        public System.DateTime FollowUpdate { get; set; }
        public Nullable<long> FollowUpExamID { get; set; }
        public string FollowUpCode { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string ReferrerFirstName { get; set; }
        public string ReferrerLastName { get; set; }
        public string FollowUpStatus { get; set; }
        public string PatientHomePhone { get; set; }
        public string PatientMobilePhone { get; set; }
        public string ReferrerPhone { get; set; }
        public string ReferrerMobilePhone { get; set; }
        public string Report { get; set; }
    }
}
