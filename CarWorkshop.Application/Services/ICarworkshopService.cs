namespace CarWorkshop.Application.Services
{
    public interface ICarworkshopService
    {
        Task Create(Domain.Entities.CarWorkshop carWorkshop);
    }
}