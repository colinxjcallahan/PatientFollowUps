using PatientFollowUp.Web.App_Data;

namespace PatientFollowUp.Web.Models
{
    public class AutoMapperMapper : IMapper
    {
        public T2 Map<T1, T2>(T1 source)
        {
            return AutoMapper.Mapper.Map<T1, T2>(source);
        }
    }
}