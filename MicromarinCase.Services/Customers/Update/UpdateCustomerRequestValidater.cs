
using FluentValidation;


namespace MicromarinCase.Services.Customers.Update
{
    public class UpdateCustomerRequestValidater : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerRequestValidater()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Müşteri ismi Boş geçilemez");
        }
    }
}
