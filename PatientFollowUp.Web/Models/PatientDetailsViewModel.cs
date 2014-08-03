using System.Collections.Generic;

namespace PatientFollowUp.Web.Models
{
    public class PatientDetailsViewModel
    {
        public FollowUpViewModel FollowUp { get; set; }
        public List<ExamViewModel> Exams { get; set; }
        public List<FollowUpClosedReasonViewModel> FollowUpClosedReasons { get; set; }
    }
}