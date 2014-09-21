using System;

namespace PatientFollowUp.Web.Application
{
    public class Date : IDate
    {
        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }
    }
}