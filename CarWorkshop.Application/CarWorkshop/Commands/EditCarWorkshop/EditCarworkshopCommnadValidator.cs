using CarWorkshop.Domain.Interfaces;
using FluentValidation;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarworkshopCommnadValidator : AbstractValidator<EditCarworkshopCommnad>
    {
        public EditCarworkshopCommnadValidator(ICarworkshopRepository repository)
        {
            RuleFor(n => n.Description)
                .NotEmpty().WithMessage("Please enter decription");

            RuleFor(n => n.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
