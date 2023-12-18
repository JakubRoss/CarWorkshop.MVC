using CarWorkshop.Domain.Interfaces;
using FluentValidation;

namespace CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommandValidator : AbstractValidator<CreateCarWorkshopCommand>
    {
        public CreateCarWorkshopCommandValidator(ICarworkshopRepository repository)
        {
            RuleFor(n => n.Name)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(20)
                .Custom((value, context) =>
                {
                    var existingCarWorkshop = repository.GetByNameAsync(value).Result;
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
