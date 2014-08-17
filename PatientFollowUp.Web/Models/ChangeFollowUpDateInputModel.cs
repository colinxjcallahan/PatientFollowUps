using System;

namespace PatientFollowUp.Web.Models
{
    public class ChangeFollowUpDateInputModel
    {
        public DateTime NewFollowUpDate { get; set; }
        public int FollowUpId { get; set; }
    }
}