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

        public async Task CommitAsync() =>await _carWorkshopDbContext.SaveChangesAsync();

        public async Task CreateAsync(Domain.Entities.CarWorkshop carWorkshop)
        {
            _carWorkshopDbContext.Add(carWorkshop);
            await _carWorkshopDbContext.SaveChangesAsync();
        }

        public async Task<Domain.Entities.CarWorkshop?> GetByNameAsync(string name) =>
            await _carWorkshopDbContext.carWorkshops.FirstOrDefaultAsync(n=>n.Name.ToLower() == name.ToLower());

        public async Task<Domain.Entities.CarWorkshop?> GetCarworkshopByEncodedNameAsync(string name) => 
            await _carWorkshopDbContext.carWorkshops.FirstOrDefaultAsync(en=>en.EncodedName.ToLower() ==name.ToLower());

        public async Task<IEnumerable<Domain.Entities.CarWorkshop>> GetCarWorkShopsAsync () => await _carWorkshopDbContext.carWorkshops.ToListAsync();
        
        public async Task DeleteCarWorkshopAsync (Domain.Entities.CarWorkshop carWorkshop)
        {
            _carWorkshopDbContext.carWorkshops.Remove(carWorkshop);
            await _carWorkshopDbContext.SaveChangesAsync();
        }

    }
}
