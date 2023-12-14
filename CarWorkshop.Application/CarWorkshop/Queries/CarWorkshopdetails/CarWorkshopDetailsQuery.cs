using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Queries.CarWorkshopdetails
{
    public class CarWorkshopDetailsQuery : IRequest<CarWorkshopDto>
    {
        public string encodedName { get;}
        public CarWorkshopDetailsQuery(string encodedName)
        {
            this.encodedName = encodedName;
        }
    }
}
