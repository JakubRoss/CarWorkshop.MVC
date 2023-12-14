using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop;
using CarWorkshop.Application.CarWorkshop.Queries.CarWorkshopdetails;
using CarWorkshop.Application.CarWorkshop.Queries.GetAllCarWorkshops;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.Presentation.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly IMediator _mediator;

        public CarWorkshopController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var carWorkshops = await _mediator.Send(new GetAllCarWorkshopsQuery());
            return View(carWorkshops);;
        }
        public IActionResult Create()
        {
            return View();
        }
        [Route("CarWorkshop/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var carWorkshop = await _mediator.Send(new CarWorkshopDetailsQuery(encodedName));
            if (carWorkshop == null)
            {
                return View();
            }
            return View(carWorkshop);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCarWorkshopCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
