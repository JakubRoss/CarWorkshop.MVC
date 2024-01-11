using CarWorkshop.Domain.Entities;
using CarWorkshop.Infrastructure.Persistence;

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
    }
}
