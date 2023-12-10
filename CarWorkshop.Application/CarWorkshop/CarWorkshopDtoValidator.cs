using CarWorkshop.Domain.Interfaces;
using FluentValidation;

namespace CarWorkshop.Application.CarWorkshop
{
    public class CarWorkshopDtoValidator : AbstractValidator<CarWorkshopDto>
    {
        public CarWorkshopDtoValidator(ICarworkshopRepository repository) 
        {
            RuleFor(n => n.Name)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(20)
                .Custom((value, context) =>
                {
                    var existingCarWorkshop = repository.GetByName(value);
                    if (existingCarWorkshop != null)
                    {
                        context.AddFailure(value, "CarWorkshop with this name already exist");
                    }
                });

            RuleFor(n => n.Description)
                .NotEmpty().WithMessage("Please enter decription");

            RuleFor(n => n.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
