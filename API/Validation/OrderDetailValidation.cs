using API.Models;
using FluentValidation;

namespace API.Validation
{
    public class OrderDetailValidation : AbstractValidator<OrderDetailModel>
    {
        public OrderDetailValidation()
        {
            RuleFor(u => u.OrderID).NotEmpty();
            RuleFor(u => u.ProductID).NotEmpty();
            RuleFor(u => u.Quantity).NotEmpty();
            RuleFor(u => u.Amount).NotEmpty();
            RuleFor(u => u.TotalAmount).NotEmpty();
            RuleFor(u => u.UserID).NotEmpty();
        }
    }
}
