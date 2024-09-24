
using FluentValidation;


namespace MicromarinCase.Services.OrderDetails.Create
{
    public class CreateOrderDetailRequestValidater : AbstractValidator<CreateOrderDetailRequest>
    {
        public CreateOrderDetailRequestValidater()
        {

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Ürün Id sıfırdan büyük olmalıdır");


            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("Sipariş Id sıfırdan büyük olmalıdır");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Ürün miktarı sıfırdan büyük olmalıdır");

        }
    }
}
