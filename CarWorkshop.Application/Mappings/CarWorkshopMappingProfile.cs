using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.DeleteCarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop;
using CarWorkshop.Application.CarWorkshopService;

namespace CarWorkshop.Application.Mappings
{
    public class CarWorkshopMappingProfile : Profile
    {
        public CarWorkshopMappingProfile(IUserContext userContext)
        {
            CreateMap<Domain.Entities.CarWorkshop, CarWorkshopDto>()
                .ForMember(c=>c.IsEditable, opt => opt.MapFrom(src => userContext != null && (src.CreatedById == userContext.GetCurrentUser()!.Id || userContext!.IsInRole(Roles.Admin))))
                .ForMember(c=>c.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(c => c.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber))
                .ForMember(c => c.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(c => c.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode)).ReverseMap();

            CreateMap<CarWorkshopDto, EditCarworkshopCommnad>().ReverseMap();
            CreateMap<CarWorkshopDto,DeleteCarWorkshopCommand>().ReverseMap();
            CreateMap<Domain.Entities.CarWorkshopService, CarWorkshopServiceDto>().ReverseMap();
        }
    }
}
