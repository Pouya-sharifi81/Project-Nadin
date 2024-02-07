using AutoMapper;
using Nadin_Application.Features.identitiesFeature.Dto;
using Nadin_Domain.Models.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin_Application.Features.identitiesFeature.MappingIdentity
{
    public class IdentityProfiles : Profile
    {
        public IdentityProfiles()
        {
            CreateMap<UserProfile, IdentityUserProfileDto>()
                .ForMember(dest => dest.Phone, opt
                => opt.MapFrom(src => src.BasicInfo.Phone))
                .ForMember(dest => dest.CurrentCity, opt
                => opt.MapFrom(src => src.BasicInfo.CurrentCity))
                .ForMember(dest => dest.EmailAddress, opt
                => opt.MapFrom(src => src.BasicInfo.EmailAddress))
                .ForMember(dest => dest.FirstName, opt
                => opt.MapFrom(src => src.BasicInfo.FirstName))
                .ForMember(dest => dest.LastName, opt
                => opt.MapFrom(src => src.BasicInfo.LastName))
                .ForMember(dest => dest.DateOfBirth, opt
                => opt.MapFrom(src => src.BasicInfo.DateOfBirth));
        }
    }
}
