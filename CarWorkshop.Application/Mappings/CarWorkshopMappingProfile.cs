using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Entities;

namespace CarWorkshop.Application.Mappings
{
    public class CarWorkshopMappingProfile : Profile
    {
        public CarWorkshopMappingProfile()
        {
            CreateMap<CarWorkshopDto, Domain.Entities.CarWorkshop>()
                .ForMember(c=>c.ContactDetails, opt=>opt.MapFrom(src=> new CarWorkshopContactDetails
                {
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    Street = src.Street,
                    PostalCode  = src.PostalCode
                })).ReverseMap();
        }
    }
}
