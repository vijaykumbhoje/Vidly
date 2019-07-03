using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Models;
using Vidly.Dtos;

namespace Vidly.App_Start
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDtos>();
            Mapper.CreateMap<Movie, MovieDtos>();
            Mapper.CreateMap<MembershipType, MembershipTypeDtos>();
            Mapper.CreateMap<Genre, GenreDtos>();

            Mapper.CreateMap<CustomerDtos, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDtos, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
         //   Mapper.CreateMap<MembershipTypeDtos, MembershipType>().ForMember(m => m.Id, opt => opt.Ignore());
        }

    }
}