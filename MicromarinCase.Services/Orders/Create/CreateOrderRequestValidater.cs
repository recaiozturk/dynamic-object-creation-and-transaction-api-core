
using FluentValidation;

namespace MicromarinCase.Services.Orders.Create
{
    public class CreateOrderRequestValidater : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidater()
        {
            RuleFor(x => x.OrderDetails).NotNull().WithMessage("Sipariş detayları Boş geçilemez")
            .Must(orderDetails => orderDetails != null && orderDetails.Count > 0)
            .WithMessage("Sipariş en az 1 tane sipariş detayı içermelidir");

            RuleFor(x => x.CustomerId)
                .GreaterThan(0).WithMessage("CustomerId sıfırdan büyük olmalıdır");
        }
    }
}
