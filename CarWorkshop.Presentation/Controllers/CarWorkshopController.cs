using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.DeleteCarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop;
using CarWorkshop.Application.CarWorkshop.Queries.CarWorkshopdetails;
using CarWorkshop.Application.CarWorkshop.Queries.GetAllCarWorkshops;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.Presentation.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper mapper;

        public CarWorkshopController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var carWorkshops = await _mediator.Send(new GetAllCarWorkshopsQuery());
            return View(carWorkshops);;
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

        [Route("CarWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var carWorkshop = await _mediator.Send(new CarWorkshopDetailsQuery(encodedName));
            if (carWorkshop == null || !carWorkshop.IsEditable)
            {
                return RedirectToAction("index");
            }
            var dto = mapper.Map<EditCarworkshopCommnad>(carWorkshop);
            return View(dto);
        }

        [HttpPost]
        [Route("CarWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName ,EditCarworkshopCommnad command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("CarWorkshop/{encodedName}/Delete")]
        public async Task<IActionResult> Delete(string encodedName, CarWorkshopDto dto)
        {
            var command = mapper.Map<DeleteCarWorkshopCommand>(dto);
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Details));
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
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
