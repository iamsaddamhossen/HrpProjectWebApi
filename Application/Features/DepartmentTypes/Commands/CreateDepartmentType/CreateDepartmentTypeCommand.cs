using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DepartmentTypes.Commands.CreateDepartmentType
{
    public partial class CreateDepartmentTypeCommand : IRequest<Response<int>>
    {
        public int DepartmentTypeId { get; set; }

        public string DepartmentTypeName { get; set; } 
    }

    public class CreateDepartmentTypeCommandHandler : IRequestHandler<CreateDepartmentTypeCommand, Response<int>>
    {
        private readonly IDepartmentTypeRepositoryAsync _departmentTypeRepository;
        private readonly IMapper _mapper;
        public CreateDepartmentTypeCommandHandler(IDepartmentTypeRepositoryAsync departmentTypeRepository, IMapper mapper)
        {
            _departmentTypeRepository = departmentTypeRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDepartmentTypeCommand request, CancellationToken cancellationToken)
        {
            var departmentType = _mapper.Map<DepartmentType>(request);
            await _departmentTypeRepository.AddAsync(departmentType);
            return new Response<int>(departmentType.DepartmentTypeId);
        }
    }
}
