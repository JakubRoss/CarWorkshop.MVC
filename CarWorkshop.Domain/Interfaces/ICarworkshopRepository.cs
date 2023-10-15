namespace CarWorkshop.Domain.Interfaces
{
    public interface ICarworkshopRepository
    {
        Task Create(Entities.CarWorkshop carWorkshop);
    }
}
