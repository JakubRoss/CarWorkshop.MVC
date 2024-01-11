using FluentValidation;

namespace CarWorkshop.Application.CarWorkshopService.Command
{
    public class CreateCarWorkshopServiceCommandValidator : AbstractValidator<CreateCarWorkshopServiceCommand>
    {
        public CreateCarWorkshopServiceCommandValidator()
        {
            RuleFor(c => c.CarWorkshopEncodedName).NotEmpty().NotNull();
            RuleFor(d => d.Description).NotEmpty().NotNull();
            RuleFor(p => p.Price).NotEmpty().NotNull();
        }
    }
}
