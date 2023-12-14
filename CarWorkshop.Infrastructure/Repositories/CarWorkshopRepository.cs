using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Domain.Entities.CarWorkshop?> GetByName(string name) =>
            await _carWorkshopDbContext.carWorkshops.FirstOrDefaultAsync(n=>n.Name.ToLower() == name.ToLower());

        public async Task<Domain.Entities.CarWorkshop?> GetCarworkshopByencodedName(string name) => 
            await _carWorkshopDbContext.carWorkshops.FirstOrDefaultAsync(en=>en.EncodedName.ToLower() ==name.ToLower());

        public async Task<IEnumerable<Domain.Entities.CarWorkshop>> GetCarWorkShops () => await _carWorkshopDbContext.carWorkshops.ToListAsync();
        


    }
}
