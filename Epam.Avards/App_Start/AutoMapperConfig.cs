using AutoMapper;
using Entities;
using Epam.Awards.ViewModels.User;
using Epam.Awards.ViewModels.Award;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.Awards.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMap()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, NewUserModel>();
                cfg.CreateMap<NewUserModel, User>().ForMember(dest => dest.ID, opt => opt.ResolveUsing(scr => 0));
                cfg.CreateMap<InfoUserModel, User>();
                cfg.CreateMap<User, InfoUserModel>().ForMember(dest => dest.Age, opt => opt.ResolveUsing(scr => Helpers.AgeCounter.GetAgeByBirthdate(scr.Birthdate))).ForMember(dest => dest.ListAwars, opt => opt.Ignore());
                cfg.CreateMap<EditUserModel, User>();
                cfg.CreateMap<User, EditUserModel>();
                cfg.CreateMap<Award, NewAwardModel>().ForMember(dest => dest.image, opt => opt.Ignore());
                cfg.CreateMap<NewAwardModel, Award>().ForMember(dest => dest.ID, opt => opt.ResolveUsing(scr => 0));
                cfg.CreateMap<Award, InfoAwardModel>();
                cfg.CreateMap<InfoAwardModel, Award>();
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}