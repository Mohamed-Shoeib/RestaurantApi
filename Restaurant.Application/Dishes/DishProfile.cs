using AutoMapper;
using Restaurant.Application.Dishes.Commands.CreateDish;
using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Dishes
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<CreateDishCommand, Dish>();
            CreateMap<Dish, DishDto>();
            CreateMap<CreateDishDto, Dish>();
        }
        
    }
}
