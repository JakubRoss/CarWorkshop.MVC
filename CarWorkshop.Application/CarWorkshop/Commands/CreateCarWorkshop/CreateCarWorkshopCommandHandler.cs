using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommandHandler : IRequestHandler<CreateCarWorkshopCommand>
    {
        private IMapper _mapper;
        private ICarworkshopRepository _carworkshopRepository;
        private readonly IUserContext userContext;

        public CreateCarWorkshopCommandHandler(IMapper mapper, ICarworkshopRepository carworkshopRepository, IUserContext userContext)
        {
            _mapper = mapper;
            _carworkshopRepository = carworkshopRepository;
            this.userContext = userContext;
        }
        async Task IRequestHandler<CreateCarWorkshopCommand>.Handle(CreateCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(request);
            carWorkshop.EncodeName();
            carWorkshop.CreatedById = userContext.GetCurrentUser().Id;
            await _carworkshopRepository.Create(carWorkshop);
        }
    }
}
