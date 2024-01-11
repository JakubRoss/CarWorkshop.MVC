using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarworkshopCommnadHandler : IRequestHandler<EditCarworkshopCommnad>
    {
        public EditCarworkshopCommnadHandler(ICarworkshopRepository carworkshopRepository, IMapper mapper, IUserContext userContext )
        {
            CarworkshopRepository = carworkshopRepository;
            Mapper = mapper;
            UserContext = userContext;
        }

        public ICarworkshopRepository CarworkshopRepository { get; }
        public IMapper Mapper { get; }
        public IUserContext UserContext { get; }

        public async Task Handle(EditCarworkshopCommnad request, CancellationToken cancellationToken)
        {
            var carworkshop = await CarworkshopRepository.GetCarworkshopByEncodedNameAsync(request.EncodedName == null ? "default" : request.EncodedName);

            if(carworkshop == null || carworkshop.CreatedById != UserContext.GetCurrentUser()!.Id)
            {
                return;
            }

                carworkshop.Description = request.Description;
                carworkshop.ContactDetails.PhoneNumber = request.PhoneNumber;
                carworkshop.ContactDetails.Street = request.Street;
                carworkshop.ContactDetails.City = request.City;
                carworkshop.ContactDetails.PostalCode = request.PostalCode;


            await CarworkshopRepository.CommitAsync();
        }
    }
}
