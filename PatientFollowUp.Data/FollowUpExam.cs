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
    
    public partial class FollowUpExam
    {
        public int Id { get; set; }
        public int FollowUpId { get; set; }
        public long FollowUpExamId { get; set; }
    
        public virtual FollowUp FollowUp { get; set; }
    }
}
