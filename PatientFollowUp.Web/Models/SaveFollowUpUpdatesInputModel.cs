﻿using System;

namespace PatientFollowUp.Web.Models
{
    public class SaveFollowUpUpdatesInputModel
    {
        public int FollowUpId { get; set; }
        public long? FollowUpExamId { get; set; }
        public bool NoRelevantFollowUpFound { get; set; }

        public int FollowUpClosedReasonId { get; set; }
        public string Comments { get; set; }

        public DateTime NewFollowUpDate { get; set; }

        public string LoggedInUserId { get; set; }
        public string FollowUpExamCptCode { get; set; }
    }
}