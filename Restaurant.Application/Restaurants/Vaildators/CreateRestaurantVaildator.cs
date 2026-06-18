using FluentValidation;
using Restaurant.Application.Restaurants.Commands.CreateRestaurant;
using Restaurant.Application.Restaurants.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurants.Vaildators
{
    public class CreateRestaurantVaildator : AbstractValidator<CreateRestaurantCommand>
    {
        private readonly List<string> validCategories = ["Italian", "Mexican", "Japanese", "American", "Indian"];

        public CreateRestaurantVaildator()
        {
            RuleFor(dto => dto.Name)
                .Length(3, 100);

            RuleFor(dto => dto.Category)
                .Must(validCategories.Contains)
                .WithMessage("Invalid category. Please choose from the valid categories.");
                //.Custom((value, context) =>
                //{
                //    var isValidCategory = validCategories.Contains(value);
                //    if(!isValidCategory)
                //    {
                //        context.AddFailure("Category", "Invalid category. Please choose from the valid categories.");
                //    }
                //});

            RuleFor(dto => dto.ContactEmail)
                .EmailAddress()
                .WithMessage("Please provide a valid email address");

            RuleFor(dto => dto.PostalCode)
                .Matches(@"^\d{2}-\d{3}$")
                .WithMessage("Please provide a valid postal code (XX-XXX).");

        }
    }
}
