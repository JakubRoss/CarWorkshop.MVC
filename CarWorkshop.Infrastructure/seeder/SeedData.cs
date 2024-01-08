using CarWorkshop.Infrastructure.Persistence;

namespace CarWorkshop.Infrastructure.seeder
{
    public class SeedData
    {
        private CarWorkshopDbContext _dbContext;

        public SeedData(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Initialize(/*IServiceProvider serviceProvider*/)
        {
            //using (var context = new CarWorkshopDbContext(serviceProvider.GetRequiredService<DbContextOptions<CarWorkshopDbContext>>()))

            if (!await _dbContext.Database.CanConnectAsync())
                return;
            if (_dbContext.carWorkshops.Any())
                return;

            var entity = new Domain.Entities.CarWorkshop
            {
                Name = "Mitschubishi ASO",
                Description = "Autoryzowany serwis ASO",
                ContactDetails = new Domain.Entities.CarWorkshopContactDetails
                {
                    City = "Gdansk",
                    Street = "Chłopska X",
                    PhoneNumber = "666 666 666",
                    PostalCode = "80-358"
                }
            };
            entity.EncodeName();
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
