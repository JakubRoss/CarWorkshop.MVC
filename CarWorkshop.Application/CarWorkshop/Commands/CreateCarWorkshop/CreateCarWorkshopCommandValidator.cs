using CarWorkshop.Domain.Interfaces;
using FluentValidation;

namespace CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommandValidator : AbstractValidator<CreateCarWorkshopCommand>
    {
        public CreateCarWorkshopCommandValidator(ICarworkshopRepository repository)
        {
            RuleFor(n => n.Name)
                .NotEmpty().WithMessage("Nazwa wymagana")
                .MinimumLength(4).WithMessage("Nazwa musi sie skladac z conajmniej 4 znakow")
                .MaximumLength(20)
                .Custom((value, context) =>
                {
                    var existingCarWorkshop = repository.GetByNameAsync(value).Result;
                    if (existingCarWorkshop != null)
                    {
                        context.AddFailure("CarWorkshop z ta nazwa juz istnieje");
                    }
                });

            RuleFor(n => n.Description)
                .MinimumLength(5).WithMessage("Opis musi sie skladac co najmniej z 5 znakow")
                .NotEmpty().WithMessage("Opis wymagany");

            RuleFor(n => n.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }

    }
}
