using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistence;
using CarWorkshop.Infrastructure.Repositories;
using CarWorkshop.Infrastructure.seeder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarWorkshop.Infrastructure.extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarWorkshopDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("CarWorkshopDbConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => {
                options.Stores.MaxLengthForKeys = 450;              //eliminuje próbę skracania kluczy i dodawania do migracji zmian niepowiązanych
            })
            .AddEntityFrameworkStores<CarWorkshopDbContext>();

            services.AddScoped<SeedData>();

            services.AddScoped<ICarworkshopRepository, CarWorkshopRepository>();
        }
    }
}
