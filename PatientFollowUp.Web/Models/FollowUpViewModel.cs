using System;

namespace PatientFollowUp.Web.Models
{
    public class FollowUpViewModel
    {
        public int FollowUpID { get; set; }
        public long AccessionNumber { get; set; }
        public string ExamType { get; set; }
        public DateTime FollowUpDate { get; set; }
        public DateTime OriginalFollowUpDate { get; set; }
        public string Sex { get; set; }
        public string PatientMRN { get; set; }

        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientHomePhone { get; set; }
        public string PatientMobilePhone { get; set; }
        public string ReferrerFirstName { get; set; }
        public string ReferrerLastName { get; set; }
        public string ReferrerPhone { get; set; }
        public string ReferrerMobilePhone { get; set; }
        public string Report { get; set; }

        public string ReferrerName
        {
            get
            {
                string referrerName = ReferrerLastName;

                if (!ReferrerFirstName.Equals("."))
                {
                    referrerName += ", " + ReferrerFirstName;
                }

                return referrerName;
            }
        }

        public string PatientName
        {
            get { return PatientLastName + ", " + PatientFirstName; }
        }
    }
}