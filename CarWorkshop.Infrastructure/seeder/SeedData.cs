using CarWorkshop.Domain.Entities;
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
                ContactDetails = new CarWorkshopContactDetails
                {
                    City = "Gdansk",
                    Street = "Chłopska 14",
                    PhoneNumber = "896 429 984",
                    PostalCode = "80-358"
                },
                Services = new List<CarWorkshopService>()
                {
                    new CarWorkshopService()
                    {
                        Description = "Wymiana Opon",
                        Price = "140PLN"
                    },
                    new CarWorkshopService()
                    {
                        Description = "Wymiana Oleju",
                        Price = "420PLN"
                    }
                }
            };
            entity.EncodeName();
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
