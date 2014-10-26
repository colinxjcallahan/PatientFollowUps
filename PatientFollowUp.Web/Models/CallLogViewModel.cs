namespace PatientFollowUp.Web.Models
{
    public class CallLogViewModel
    {
        public int CallLogId { get; set; }
        public string CallLogText { get; set; }
        public int? CallLogTypeId { get; set; }
        public int FollowUpId { get; set; }
    }
}