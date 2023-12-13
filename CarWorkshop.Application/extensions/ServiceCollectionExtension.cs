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

            services.AddAutoMapper(typeof(CarWorkshopMappingProfile));
            services.AddValidatorsFromAssemblyContaining<CreateCarWorkshopCommandValidator>()   //nie potrzeba za kazdym razem rejestrowac validatorow - wystarczy w parametrze generycznym dodac tylko jeden dowonlny validator, reszta zostanie dodana automatycznie
                .AddFluentValidationAutoValidation()                //domyslna walidacja z frameworka ASP.NEt zostanie zastapiona walidacja z fluentValidation
                .AddFluentValidationClientsideAdapters();           //dodanie regul walidacji po stronie frontendu - client side

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateCarWorkshopCommand)));
        }
    }
}
