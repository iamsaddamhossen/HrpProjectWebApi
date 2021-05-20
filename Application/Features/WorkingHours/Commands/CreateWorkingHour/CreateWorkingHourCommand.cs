using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WorkingHours.Commands.CreateWorkingHour
{
    public partial class CreateWorkingHourCommand : IRequest<Response<int>>
    {
        public int WorkingHourId { get; set; }

        public string WorkingHourDuration { get; set; }
    }

    public class CreateWorkingHourCommandHandler : IRequestHandler<CreateWorkingHourCommand, Response<int>>
    {
        private readonly IWorkingHourRepositoryAsync _workingHourRepository;
        private readonly IMapper _mapper;
        public CreateWorkingHourCommandHandler(IWorkingHourRepositoryAsync workingHourRepository, IMapper mapper)
        {
            _workingHourRepository = workingHourRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWorkingHourCommand request, CancellationToken cancellationToken)
        {
            var workingHour = _mapper.Map<WorkingHour>(request);
            await _workingHourRepository.AddAsync(workingHour);
            return new Response<int>(workingHour.WorkingHourId);
        }
    }
}
