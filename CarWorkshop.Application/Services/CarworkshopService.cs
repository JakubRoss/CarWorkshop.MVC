using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Interfaces;

namespace CarWorkshop.Application.Services
{
    public class CarworkshopService : ICarworkshopService
    {
        private ICarworkshopRepository _carworkshopRepository;
        private IMapper _mapper;

        public CarworkshopService(ICarworkshopRepository carworkshopRepository, IMapper mapper)
        {
            _carworkshopRepository = carworkshopRepository;
            _mapper = mapper;
        }
        public async Task Create(CarWorkshopDto carWorkshopDto)
        {
            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(carWorkshopDto);
            carWorkshop.EncodeName();
            await _carworkshopRepository.Create(carWorkshop);
        }

        public async Task<IEnumerable<CarWorkshopDto>> GetAll()
        {
            var carWorkShops = await _carworkshopRepository.GetCarWorkShops();
            return _mapper.Map<IEnumerable<CarWorkshopDto>>(carWorkShops);
        }
    }
}
