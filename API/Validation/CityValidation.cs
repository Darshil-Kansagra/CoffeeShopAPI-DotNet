using API.Models;
using FluentValidation;

namespace API.Validation
{
    public class CityValidation : AbstractValidator<CityModel>
    {
        public CityValidation() 
        {
            RuleFor(u => u.CityName).NotEmpty();
            RuleFor(u => u.CountryID).NotEmpty();
            RuleFor(u => u.StateID).NotEmpty();
            RuleFor(u => u.CityCode).NotEmpty();
        }
    }
}
