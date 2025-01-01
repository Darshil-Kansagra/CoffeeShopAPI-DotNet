using API.Models;
using FluentValidation;

namespace API.Validation
{
    public class OrderValidation : AbstractValidator<OrderModel>
    {
        public OrderValidation()
        {
            RuleFor(u => u.OrderDate).NotEmpty();
            RuleFor(u => u.CustomerID).NotEmpty();
            RuleFor(u => u.UserID).NotEmpty();
            RuleFor(u => u.PaymentMode).NotEmpty();
            RuleFor(u => u.TotalAmount).NotEmpty();
            RuleFor(u => u.ShippingAddress).NotEmpty();
        }
    }
}
