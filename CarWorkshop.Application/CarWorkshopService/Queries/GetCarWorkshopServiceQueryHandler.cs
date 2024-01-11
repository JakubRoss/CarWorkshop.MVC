using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshopService.Queries
{
    internal class GetCarWorkshopServiceQueryHandler : IRequestHandler<GetCarWorkshopServiceQuery, IEnumerable<CarWorkshopServiceDto>>
    {
        public GetCarWorkshopServiceQueryHandler(ICarWorkshopServiceRepository carWorkshopServiceRepository, IMapper mapper)
        {
            CarWorkshopServiceRepository = carWorkshopServiceRepository;
            Mapper = mapper;
        }

        private ICarWorkshopServiceRepository CarWorkshopServiceRepository { get; }
        public IMapper Mapper { get; }

        public async Task<IEnumerable<CarWorkshopServiceDto>> Handle(GetCarWorkshopServiceQuery request, CancellationToken cancellationToken)
        {
            var services = await CarWorkshopServiceRepository.GetCarWorkshopServicesAsync(request.EncodedName);
            if (services == null)
            {
                return new List<CarWorkshopServiceDto>();
            }
            var servicesDto = Mapper.Map<List<CarWorkshopServiceDto>>(services);
            return servicesDto;
        }
    }
}
