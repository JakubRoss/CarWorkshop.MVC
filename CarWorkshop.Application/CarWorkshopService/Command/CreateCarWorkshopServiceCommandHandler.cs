using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Entities;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshopService.Command
{
    public class CreateCarWorkshopServiceCommandHandler : IRequestHandler<CreateCarWorkshopServiceCommand>
    {
        public CreateCarWorkshopServiceCommandHandler(ICarWorkshopServiceRepository carWorkshopServiceRepository, IUserContext userContext, ICarworkshopRepository carworkshopRepository)
        {
            CarWorkshopServiceRepository = carWorkshopServiceRepository;
            UserContext = userContext;
            CarworkshopRepository = carworkshopRepository;
        }

        private ICarWorkshopServiceRepository CarWorkshopServiceRepository { get; }
        private IUserContext UserContext { get; }
        public ICarworkshopRepository CarworkshopRepository { get; }

        public async Task Handle(CreateCarWorkshopServiceCommand request, CancellationToken cancellationToken)
        {
            var user = UserContext.GetCurrentUser();
            var carWorkshop = await CarworkshopRepository.GetCarworkshopByEncodedNameAsync(request.CarWorkshopEncodedName);

            var isEditable = carWorkshop!.CreatedById != null && (carWorkshop.CreatedById == user!.Id || UserContext.IsInRole(Roles.Admin));

            if (!isEditable)
            {
                return;
            }

            var newService = new Domain.Entities.CarWorkshopService()
            {
                Description = request.Description,
                Price = request.Price,
                CarWorkshopId = carWorkshop.Id,
            };

            await CarWorkshopServiceRepository.CreateCarWorkshopservice(newService);
        }
    }
}
