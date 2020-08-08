using CentralDeErros.Model.Models;
using CentralDeErros.Transport;

namespace CentralDeErros.API
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Model.Models.Environment, EnvironmentDTO>().ReverseMap();
            CreateMap<Level, LevelDTO>().ReverseMap();
            CreateMap<Microsservice, MicrosserviceDTO>().ReverseMap();
        }
    }
}
