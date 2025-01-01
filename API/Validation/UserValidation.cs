using API.Models;
using FluentValidation;

namespace API.Validation
{
    public class UserValidation : AbstractValidator<UserModel>
    {
        public UserValidation()
        {
            RuleFor(u => u.UserName).NotEmpty();
            RuleFor(u => u.Email).NotEmpty().EmailAddress();
            RuleFor(u => u.Password).Length(6,10);
            RuleFor(u => u.MobileNo).NotEmpty().Length(10);
            RuleFor(u => u.Address).NotEmpty();
        }
    }
}
