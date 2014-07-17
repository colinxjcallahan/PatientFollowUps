using System;

namespace PatientFollowUp.Web.App_Data
{
    public class Date : IDate
    {
        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }
    }
}