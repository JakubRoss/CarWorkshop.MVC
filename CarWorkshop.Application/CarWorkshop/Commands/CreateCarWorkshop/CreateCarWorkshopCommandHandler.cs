﻿using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommandHandler : IRequestHandler<CreateCarWorkshopCommand>
    {
        private IMapper _mapper;
        private ICarworkshopRepository _carworkshopRepository;

        public CreateCarWorkshopCommandHandler(IMapper mapper, ICarworkshopRepository carworkshopRepository)
        {
            _mapper = mapper;
            _carworkshopRepository = carworkshopRepository;
        }
        async Task IRequestHandler<CreateCarWorkshopCommand>.Handle(CreateCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(request);
            carWorkshop.EncodeName();
            await _carworkshopRepository.Create(carWorkshop);
        }
    }
}
