using AutoMapper;
using Domain.Entity;
using Application.DTO;


namespace Transversal.Mapper
{
    public class MapppingsProfile :Profile
    {
        public MapppingsProfile()
        {
            CreateMap<Customers,CustomersDTO>().ReverseMap();

            CreateMap<Users, UsersDto>().ReverseMap();

            //CreateMap<Customers, CustomersDTO>().ReverseMap() Cuando los campos no coinciden
            //    .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId)); 
        }

    }
}