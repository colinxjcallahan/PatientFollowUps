using PatientFollowUp.Data;
using PatientFollowUp.Web.Models;

namespace PatientFollowUp.Web
{
    public class AutomapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<FollowUpWithSynonymData, FollowUpViewModel>();
            AutoMapper.Mapper.CreateMap<Exam, ExamViewModel>();
            AutoMapper.Mapper.CreateMap<SaveFollowUpUpdatesInputModel, FollowUp>();
            AutoMapper.Mapper.CreateMap<FollowUpClosedReason, FollowUpClosedReasonViewModel>();
            AutoMapper.Mapper.CreateMap<FollowUp, FollowUpHistory>();
            AutoMapper.Mapper.CreateMap<FollowUpHistory, FollowUpHistoryViewModel>();
            AutoMapper.Mapper.CreateMap<FollowUpCallLog, FollowUpCallLogViewModel>();
            AutoMapper.Mapper.CreateMap<CreateCallLogInputModel, FollowUpCallLog>();

        }
    }
}