namespace PatientFollowUp.Web.Models
{
    public class CreateCallLogInputModel
    {
        public string FollowUpCallLogText { get; set; }
        public int? FollowUpCallLogTypeId { get; set; }
        public int FollowUpId { get; set; }
    }
}