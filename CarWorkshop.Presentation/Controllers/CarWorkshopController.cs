using CarWorkshop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.Presentation.Controllers
{
    public class CarWorkshopController : Controller
    {
        private ICarworkshopService _carworkshopService;

        public CarWorkshopController(ICarworkshopService carworkshopService) 
        {
            _carworkshopService = carworkshopService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            await _carworkshopService.Create(carWorkshop);
            return Ok();
        }
    }
}
