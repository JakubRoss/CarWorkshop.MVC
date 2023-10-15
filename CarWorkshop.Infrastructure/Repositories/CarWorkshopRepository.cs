using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistence;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class CarWorkshopRepository : ICarworkshopRepository
    {
        private CarWorkshopDbContext _carWorkshopDbContext;

        public CarWorkshopRepository(CarWorkshopDbContext carWorkshopDbContext) 
        {
            _carWorkshopDbContext = carWorkshopDbContext;
        }

        public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            _carWorkshopDbContext.Add(carWorkshop);
            await _carWorkshopDbContext.SaveChangesAsync();
        }
    }
}
