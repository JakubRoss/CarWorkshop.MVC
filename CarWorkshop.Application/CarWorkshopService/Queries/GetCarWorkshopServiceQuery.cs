using MediatR;

namespace CarWorkshop.Application.CarWorkshopService.Queries
{
    public class GetCarWorkshopServiceQuery : IRequest<IEnumerable<CarWorkshopServiceDto>>
    {
        public string EncodedName { get; set; } = default!;
    }
}
