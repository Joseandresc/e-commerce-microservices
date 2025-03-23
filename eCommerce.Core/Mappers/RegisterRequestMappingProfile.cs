﻿using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;


namespace eCommerce.Core.Mappers
{
    public class RegisterRequestMappingProfile : Profile
    {
        // Constructor to configure the mapping profile
        public RegisterRequestMappingProfile()
        {

            CreateMap<RegisterRequest, ApplicationUser>()
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
              .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password)) // In a real application, passwords should be hashed.
              .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
              .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));
        }
    }
}
