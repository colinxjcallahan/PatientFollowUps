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

        }
    }
}