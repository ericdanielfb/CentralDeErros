using AutoMapper;
using CentralDeErros.Model.Models;
using CentralDeErros.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeErros.API
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Model.Models.Environment, EnvironmentDTO>().ReverseMap();
        }
    }
}
