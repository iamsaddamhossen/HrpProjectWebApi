using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WorkingHours.Commands.UpdateWorkingHour 
{
    public class UpdateWorkingHourCommand : IRequest<Response<int>>
    {
        public int WorkingHourId { get; set; }
        public string WorkingHourDuration { get; set; } 

        public class UpdateWorkingHourCommandHandler : IRequestHandler<UpdateWorkingHourCommand, Response<int>>
        {
            private readonly IWorkingHourRepositoryAsync _workingHourRepository; 
            public UpdateWorkingHourCommandHandler(IWorkingHourRepositoryAsync workingHourRepository)
            {
                _workingHourRepository = workingHourRepository;
            }
            public async Task<Response<int>> Handle(UpdateWorkingHourCommand command, CancellationToken cancellationToken)
            {
                var workingHour = await _workingHourRepository.GetByIdAsync(command.WorkingHourId);

                if (workingHour == null)
                {
                    throw new ApiException($"Working Hour Not Found.");
                }
                else
                {
                    workingHour.WorkingHourId = command.WorkingHourId;
                    workingHour.WorkingHourDuration = command.WorkingHourDuration;
                    await _workingHourRepository.UpdateAsync(workingHour);
                    return new Response<int>(workingHour.WorkingHourId);
                }
            }
        }
    }
}
