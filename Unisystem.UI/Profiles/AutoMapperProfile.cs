using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unisystem.Domain.Entities;
using Unisystem.UI.ViewModels;

namespace Unisystem.UI.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserVM, User>();
        }
    }
}