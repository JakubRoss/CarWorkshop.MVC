using CarWorkshop.Domain.Entities;

namespace CarWorkshop.Domain.Interfaces
{
    public interface ICarWorkshopServiceRepository
    {
        Task CreateCarWorkshopservice(CarWorkshopService service);
        Task<IEnumerable<CarWorkshopService>?> GetCarWorkshopServicesAsync(string encodedName);
    }
}