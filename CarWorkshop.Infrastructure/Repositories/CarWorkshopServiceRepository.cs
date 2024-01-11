using CarWorkshop.Domain.Entities;
using CarWorkshop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class CarWorkshopServiceRepository : Domain.Interfaces.ICarWorkshopServiceRepository
    {
        public CarWorkshopServiceRepository(CarWorkshopDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public CarWorkshopDbContext DbContext { get; }

        public async Task CreateCarWorkshopservice(CarWorkshopService service)
        {
            await DbContext.AddAsync(service);
            await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarWorkshopService>?> GetCarWorkshopServicesAsync(string encodedName)
        {
            var carworkshop = await DbContext.carWorkshops.Include( s => s.Services).FirstOrDefaultAsync(p => p.EncodedName == encodedName);
            return carworkshop!.Services;
        }
    }
}
