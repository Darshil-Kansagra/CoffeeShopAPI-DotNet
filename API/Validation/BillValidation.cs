using API.Models;
using FluentValidation;

namespace API.Validation
{
    public class BillValidation : AbstractValidator<BillModel>
    {
        public BillValidation()
        {
            RuleFor(u => u.BillNumber).NotEmpty().WithMessage("Not Null");
            RuleFor(u => u.BillDate).NotEmpty();
            RuleFor(u => u.OrderID).NotEmpty();
            RuleFor(u => u.TotalAmount).NotEmpty();
            RuleFor(u => u.Discount).NotEmpty();
            RuleFor(u => u.NetAmount).NotEmpty();
            RuleFor(u => u.UserID).NotEmpty();
        }
    }
}
