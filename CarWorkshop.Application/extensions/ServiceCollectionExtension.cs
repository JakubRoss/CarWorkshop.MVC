using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop;
using CarWorkshop.Application.Mappings;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarWorkshop.Infrastructure.extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddAplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();
            services.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new CarWorkshopMappingProfile(userContext));
            }).CreateMapper());

            services.AddValidatorsFromAssemblyContaining<CreateCarWorkshopCommandValidator>()   //nie potrzeba za kazdym razem rejestrowac validatorow - wystarczy w parametrze generycznym dodac tylko jeden dowonlny validator, reszta zostanie dodana automatycznie
                .AddFluentValidationAutoValidation()                //domyslna walidacja z frameworka ASP.NET zostanie zastapiona walidacja z fluentValidation
                .AddFluentValidationClientsideAdapters();           //dodanie regul walidacji po stronie frontendu - client side

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateCarWorkshopCommand)));
        }
    }
}
