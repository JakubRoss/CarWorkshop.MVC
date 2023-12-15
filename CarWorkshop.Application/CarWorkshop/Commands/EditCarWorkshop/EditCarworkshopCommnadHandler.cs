using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarworkshopCommnadHandler : IRequestHandler<EditCarworkshopCommnad>
    {
        public EditCarworkshopCommnadHandler(ICarworkshopRepository carworkshopRepository, IMapper mapper)
        {
            CarworkshopRepository = carworkshopRepository;
            Mapper = mapper;
        }

        public ICarworkshopRepository CarworkshopRepository { get; }
        public IMapper Mapper { get; }

        public async Task Handle(EditCarworkshopCommnad request, CancellationToken cancellationToken)
        {
            var carworkshop = await CarworkshopRepository.GetCarworkshopByencodedName(request.EncodedName == null ? "default" : request.EncodedName);

            if(carworkshop == null)
            {
                return;
            }

                carworkshop.Description = request.Description;
                carworkshop.ContactDetails.PhoneNumber = request.PhoneNumber;
                carworkshop.ContactDetails.Street = request.Street;
                carworkshop.ContactDetails.City = request.City;
                carworkshop.ContactDetails.PostalCode = request.PostalCode;


            await CarworkshopRepository.Commit();
        }
    }
}
