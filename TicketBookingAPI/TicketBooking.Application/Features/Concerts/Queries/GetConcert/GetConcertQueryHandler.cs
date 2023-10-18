﻿using MediatR;
using TicketBooking.Application.Exceptions;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Application.Features.Concerts.Queries.GetConcert
{
    public class GetConcertQueryHandler : IRequestHandler<GetConcertQuery, Concert>
    {
        private readonly IConcertRepository _concertRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetConcertQueryHandler(
            IConcertRepository concertRepository, 
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _concertRepository = concertRepository;
        }

        public async Task<Concert> Handle(GetConcertQuery request, CancellationToken cancellationToken)
        {
            var concert = await _concertRepository.GetByIdAsync(request.Id, cancellationToken);
            if (concert is null)
            {
                throw new NotFoundException("There is no such concert");
            }

            return concert;
        }
    }
}
