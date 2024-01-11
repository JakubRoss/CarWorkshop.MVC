using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Entities;
using CarWorkshop.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace CarWorkshop.Infrastructure.seeder
{
    public class SeedData
    {
        private CarWorkshopDbContext _dbContext;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public SeedData(CarWorkshopDbContext dbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task Initialize()
        {

            if (!await _dbContext.Database.CanConnectAsync())
                return;
            if (_dbContext.carWorkshops.Any())
                return;

            var username = "admin@test.pl";
            var password = "Admin123!";

            var roleName = Roles.Admin;


            var roleExists = await roleManager.RoleExistsAsync(roleName);

            if (!roleExists)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            var user = await userManager.FindByNameAsync(username);

            if (user == null)
            {
                user = new IdentityUser { UserName = username, Email = username };
                await userManager.CreateAsync(user, password);


                await userManager.AddToRoleAsync(user, roleName);
            }

            var admin= await userManager.FindByNameAsync(username);
            var entity = new Domain.Entities.CarWorkshop
            {
                Name = "Mitschubishi ASO",
                Description = "Autoryzowany serwis ASO",
                CreatedById = admin!.Id,
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
