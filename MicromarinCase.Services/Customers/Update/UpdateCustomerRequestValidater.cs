
using FluentValidation;

namespace MicromarinCase.Services.Customers.Update
{
    public class UpdateCustomerRequestValidater : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerRequestValidater()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Müşteri ismi Boş geçilemez");
        }
    }
}
