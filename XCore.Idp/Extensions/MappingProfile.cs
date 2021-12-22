using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCore.Idp.Models;
using XCore.Idp.Models.ViewModels;

namespace XCore.Idp
{
    public class MappingProfile : Profile 
    {
        public MappingProfile() 
        { 
            CreateMap<UserRegistrationModel, User>().ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        } 
    }
}
