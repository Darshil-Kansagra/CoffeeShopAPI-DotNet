using API.Models;
using FluentValidation;

namespace API.Validation
{
    public class ProductValidation : AbstractValidator<ProductModel>
    {
        public ProductValidation()
        {
            RuleFor(u => u.ProductName).NotEmpty();
            RuleFor(u => u.ProductPrice).NotEmpty();
            RuleFor(u => u.ProductCode).NotEmpty();
            RuleFor(u => u.Description).NotEmpty();
            RuleFor(u => u.UserID).NotEmpty();
        }
    }
}
