using CarWorkshop.Domain.Entities;

namespace CarWorkshop.Domain.Interfaces
{
    public interface ICarworkshopRepository
    {
        Task CreateAsync(Entities.CarWorkshop carWorkshop);
        Task<Entities.CarWorkshop?> GetByNameAsync(string name);
        Task<IEnumerable<Entities.CarWorkshop>> GetCarWorkShopsAsync();
        Task<Entities.CarWorkshop?> GetCarworkshopByEncodedNameAsync(string name);
        Task CommitAsync();
        Task DeleteCarWorkshopAsync(Entities.CarWorkshop carWorkshop);
    }
}
