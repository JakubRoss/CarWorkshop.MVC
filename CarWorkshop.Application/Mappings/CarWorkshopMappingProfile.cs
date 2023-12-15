using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop;
using CarWorkshop.Domain.Entities;

namespace CarWorkshop.Application.Mappings
{
    public class CarWorkshopMappingProfile : Profile
    {
        public CarWorkshopMappingProfile()
        {
            CreateMap<Domain.Entities.CarWorkshop, CarWorkshopDto>()
                .ForMember(c=>c.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(c => c.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber))
                .ForMember(c => c.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(c => c.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode)).ReverseMap();



            CreateMap<CarWorkshopDto, EditCarworkshopCommnad>().ReverseMap();
        }
    }
}
