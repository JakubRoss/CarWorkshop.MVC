using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.DeleteCarWorkshop
{
    public class DeleteCarWorkshopCommand : IRequest
    {
        public string? encodedName { get; set; }
    }
}
