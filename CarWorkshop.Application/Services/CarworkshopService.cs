using CarWorkshop.Domain.Interfaces;

namespace CarWorkshop.Application.Services
{
    public class CarworkshopService : ICarworkshopService
    {
        private ICarworkshopRepository _carworkshopRepository;

        public CarworkshopService(ICarworkshopRepository carworkshopRepository)
        {
            _carworkshopRepository = carworkshopRepository;
        }
        public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            carWorkshop.EncodeName();
            await _carworkshopRepository.Create(carWorkshop);
        }
    }
}
