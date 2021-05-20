using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DepartmentTypes.Commands.DeleteDepartmentTypeById 
{
    public class DeleteDepartmentTypeByIdCommand : IRequest<Response<int>>
    {
        public int DepartmentTypeById { get; set; } 
        public class DeleteDepartmentTypeByIdCommandHandler : IRequestHandler<DeleteDepartmentTypeByIdCommand, Response<int>>
        {
            private readonly IDepartmentTypeRepositoryAsync _departmentTypeRepository; 
            public DeleteDepartmentTypeByIdCommandHandler(IDepartmentTypeRepositoryAsync departmentTypeRepository)
            {
                _departmentTypeRepository = departmentTypeRepository;
            }
            public async Task<Response<int>> Handle(DeleteDepartmentTypeByIdCommand command, CancellationToken cancellationToken)
            {
                var departmentType = await _departmentTypeRepository.GetByIdAsync(command.DepartmentTypeById);
                if (departmentType == null) throw new ApiException($"Department Type Not Found.");
                await _departmentTypeRepository.DeleteAsync(departmentType);
                return new Response<int>(departmentType.DepartmentTypeId);
            }
        }
    }
}
