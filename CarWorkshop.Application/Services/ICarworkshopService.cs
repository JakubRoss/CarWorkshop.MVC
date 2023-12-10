using CarWorkshop.Application.CarWorkshop;

namespace CarWorkshop.Application.Services
{
    public interface ICarworkshopService
    {
        Task Create(CarWorkshopDto carWorkshop);
        Task<IEnumerable<CarWorkshopDto>> GetAll();
    }
}