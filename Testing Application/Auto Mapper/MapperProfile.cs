using AutoMapper;
using TestingApplication.Model;

namespace TestingApplication.Auto_Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Job,Category>();
        }
    }
}
