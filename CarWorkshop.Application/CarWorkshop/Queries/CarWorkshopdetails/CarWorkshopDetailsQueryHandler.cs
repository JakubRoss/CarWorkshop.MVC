using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Queries.CarWorkshopdetails
{
    public class CarWorkshopDetailsQueryHandler : IRequestHandler<CarWorkshopDetailsQuery, CarWorkshopDto>
    {
        public CarWorkshopDetailsQueryHandler(ICarworkshopRepository carworkshopRepository, IMapper mapper)
        {
            CarworkshopRepository = carworkshopRepository;
            Mapper = mapper;
        }

        public ICarworkshopRepository CarworkshopRepository { get; }
        private IMapper Mapper { get; }

        public async Task<CarWorkshopDto> Handle(CarWorkshopDetailsQuery request, CancellationToken cancellationToken)
        {
            var carWorkshop = await CarworkshopRepository.GetCarworkshopByEncodedNameAsync(request.encodedName);
            var carWorkshopDto = Mapper.Map<CarWorkshopDto>(carWorkshop);
            return carWorkshopDto;
        }
    }
}
