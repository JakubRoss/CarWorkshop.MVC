using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Queries.GetAllCarWorkshops
{
    public class GetAllCarWorkshopsQueryHandler : IRequestHandler<GetAllCarWorkshopsQuery, IEnumerable<CarWorkshopDto>>
    {
        public ICarworkshopRepository _carworkshopRepository { get; }
        public IMapper _mapper { get; }

        public GetAllCarWorkshopsQueryHandler(ICarworkshopRepository carworkshopRepository, IMapper mapper)
        {
            _carworkshopRepository = carworkshopRepository;
            _mapper = mapper;
        }

        async Task<IEnumerable<CarWorkshopDto>> IRequestHandler<GetAllCarWorkshopsQuery, IEnumerable<CarWorkshopDto>>.Handle(GetAllCarWorkshopsQuery request, CancellationToken cancellationToken)
        {
            var carWorkShops = await _carworkshopRepository.GetCarWorkShopsAsync();
            return _mapper.Map<IEnumerable<CarWorkshopDto>>(carWorkShops);
        }
    }
}
