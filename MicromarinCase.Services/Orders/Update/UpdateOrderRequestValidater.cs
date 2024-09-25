
using FluentValidation;

namespace MicromarinCase.Services.Orders.Update
{
    public class UpdateOrderRequestValidater : AbstractValidator<UpdateOrdertRequest>
    {
        public UpdateOrderRequestValidater()
        {
            RuleFor(x => x.OrderDetails).NotNull().WithMessage("Sipariş detayları Boş geçilemez")
            .Must(orderDetails => orderDetails != null && orderDetails.Count > 0)
            .WithMessage("Sipariş en az 1 tane sipariş detayı içermelidir");

            RuleFor(x => x.CustomerId)
                .GreaterThan(0).WithMessage("CustomerId sıfırdan büyük olmalıdır");
        }
    }
}
