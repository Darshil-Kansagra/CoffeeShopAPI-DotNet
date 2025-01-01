using API.Models;
using FluentValidation;

namespace API.Validation
{
    public class CustomerValidation : AbstractValidator<CustomerModel>
    {
        public CustomerValidation() 
        {
            RuleFor(u => u.CustomerName).NotEmpty();
            RuleFor(u => u.HomeAddress).NotEmpty();
            RuleFor(u => u.Email).NotEmpty().EmailAddress();
            RuleFor(u => u.MobileNo).NotEmpty();
            RuleFor(u => u.GSTNO).NotEmpty();
            RuleFor(u => u.CityName).NotEmpty();
            RuleFor(u => u.NetAmount).NotEmpty();
            RuleFor(u => u.PinCode).NotEmpty();
            RuleFor(u => u.UserID).NotEmpty();
        }
    }
}
