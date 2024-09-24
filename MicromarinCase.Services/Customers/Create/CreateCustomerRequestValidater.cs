
using FluentValidation;


namespace MicromarinCase.Services.Customers.Create
{
    public class CreateCustomerRequestValidater : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidater()
        {

            RuleFor(x => x.Name).NotNull().WithMessage("Müşteri ismi Boş geçilemez");

        }
    }
}
