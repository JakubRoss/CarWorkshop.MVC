namespace CarWorkshop.Domain.Interfaces
{
    public interface ICarworkshopRepository
    {
        Task Create(Entities.CarWorkshop carWorkshop);
        Task<Entities.CarWorkshop?> GetByName(string name);
        Task<IEnumerable<Entities.CarWorkshop>> GetCarWorkShops();
        Task<Entities.CarWorkshop?> GetCarworkshopByencodedName(string name);
    }
}
