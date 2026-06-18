using AutoMapper;
using Restaurant.Application.Restaurants.Commands.CreateRestaurant;
using Restaurant.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurants
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<UpdateRestaurantCommand, Resturant>();
            CreateMap<CreateRestaurantCommand, Resturant>()
                .ForMember(d => d.Address, opt => opt.MapFrom(src => new Address
                {
                    City = src.City,
                    Street = src.Street,
                    PostalCode = src.PostalCode
                }));
            CreateMap<Resturant, RestaurantDto>()
                .ForMember(d => d.City, opt =>
                    opt.MapFrom(src => src.Address == null ? null : src.Address.City))
                .ForMember(d => d.PostalCode, opt =>
                    opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
                .ForMember(d => d.Street, opt =>
                    opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
                .ForMember(d => d.Dishes, opt => opt.MapFrom(src => src.Dishes));
        }
    }
}
