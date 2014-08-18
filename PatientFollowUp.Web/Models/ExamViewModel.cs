using System;

namespace PatientFollowUp.Web.Models
{
    public class ExamViewModel
    {
        public long ExamID { get; set; }
        public string ExamType { get; set; }
        public string Description { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public long AccessionNumber { get; set; }
    }
}