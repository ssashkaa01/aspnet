using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Entities;
using WebApplication.Models;

namespace WebApplication
{
    public class BicycleMappingProfile : Profile
    {
        public BicycleMappingProfile()
        {
            CreateMap<Photo, PhotoVM>()
                    .ForMember("UrlLink", opt => opt.MapFrom(c => "/Uploading/" + c.Image));
        }
    }


    public class MyAutoMapperConfig
    {
        public static Mapper GetAutoMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<BicycleMappingProfile>());

            var mapper = new Mapper(config);

            return mapper;
        }
    }
}