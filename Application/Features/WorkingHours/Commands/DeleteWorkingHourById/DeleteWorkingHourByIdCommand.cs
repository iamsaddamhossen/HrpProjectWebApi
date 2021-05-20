using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WorkingHours.Commands.DeleteWorkingHourById 
{
    public class DeleteWorkingHourByIdCommand : IRequest<Response<int>>
    {
        public int WorkingHourById { get; set; } 
        public class DeleteWorkingHourByIdCommandHandler : IRequestHandler<DeleteWorkingHourByIdCommand, Response<int>>
        {
            private readonly IWorkingHourRepositoryAsync _workingHourRepository; 
            public DeleteWorkingHourByIdCommandHandler(IWorkingHourRepositoryAsync workingHourRepository)
            {
                _workingHourRepository = workingHourRepository;
            }
            public async Task<Response<int>> Handle(DeleteWorkingHourByIdCommand command, CancellationToken cancellationToken)
            {
                var workingHour = await _workingHourRepository.GetByIdAsync(command.WorkingHourById);
                if (workingHour == null) throw new ApiException($"Working Hour Not Found.");
                await _workingHourRepository.DeleteAsync(workingHour);
                return new Response<int>(workingHour.WorkingHourId);
            }
        }
    }
}
