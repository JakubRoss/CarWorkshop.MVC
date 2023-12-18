using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.DeleteCarWorkshop
{
    public class DeleteCarWorkshopCommandHandler : IRequestHandler<DeleteCarWorkshopCommand>
    {
        public DeleteCarWorkshopCommandHandler(ICarworkshopRepository repository, IUserContext user)
        {
            Repository = repository;
            User = user;
        }

        public ICarworkshopRepository Repository { get; }
        public IUserContext User { get; }

        public async Task Handle(DeleteCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var car = await Repository.GetCarworkshopByEncodedNameAsync(request.encodedName == null ? "def" : request.encodedName); 
            if (car == null || User.GetCurrentUser() == null || User.GetCurrentUser().Id != car.CreatedById)
                return;
            await Repository.DeleteCarWorkshopAsync(car);
        }
    }
}
