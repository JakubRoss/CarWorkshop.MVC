using CarWorkshop.Application.CarWorkshop;
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarWorkshopDto carWorkshop)
        {
            await _carworkshopService.Create(carWorkshop);
            return RedirectToAction(nameof(Create));
        }
    }
}
