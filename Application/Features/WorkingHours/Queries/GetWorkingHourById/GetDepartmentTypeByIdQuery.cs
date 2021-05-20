using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WorkingHours.Queries.GetWorkingHourById 
{
    public class GetWorkingHourByIdQuery : IRequest<Response<WorkingHour>>
    {
        public int WorkingHourId { get; set; } 
        public class GetWorkingHourByIdQueryHandler : IRequestHandler<GetWorkingHourByIdQuery, Response<WorkingHour>>
        {
            private readonly IWorkingHourRepositoryAsync _workingHourRepository; 
            public GetWorkingHourByIdQueryHandler(IWorkingHourRepositoryAsync workingHourRepository) 
            {
                _workingHourRepository = workingHourRepository;
            }
            public async Task<Response<WorkingHour>> Handle(GetWorkingHourByIdQuery query, CancellationToken cancellationToken)
            {
                var workingHour = await _workingHourRepository.GetByIdAsync(query.WorkingHourId);
                if (workingHour == null) throw new ApiException($"Working Hour Not Found.");
                return new Response<WorkingHour>(workingHour);
            }
        }
    }
}
