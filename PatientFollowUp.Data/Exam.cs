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
    
    public partial class Exam
    {
        public long ExamID { get; set; }
        public string ExamCptCode { get; set; }
        public string ExamType { get; set; }
        public string Description { get; set; }
        public string PatientMRN { get; set; }
        public Nullable<System.DateTime> ScheduleDate { get; set; }
        public Nullable<System.DateTime> CompletionDate { get; set; }
        public string Status { get; set; }
        public string AccessionNumber { get; set; }
        public string LocationCode { get; set; }
    }
}
