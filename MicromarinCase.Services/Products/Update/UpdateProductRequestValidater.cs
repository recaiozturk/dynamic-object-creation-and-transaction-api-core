
using FluentValidation;


namespace MicromarinCase.Services.Products.Update
{
    public class UpdateProductRequestValidater : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidater()
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ürün ismi gereklidir")
                .Length(3, 10).WithMessage("Ürün ismi 3 ile 10 karakter arasında olmalıdır");


            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("ürün fiyatı sıfırdan büyük olmalıdır");

        }
    }
}
