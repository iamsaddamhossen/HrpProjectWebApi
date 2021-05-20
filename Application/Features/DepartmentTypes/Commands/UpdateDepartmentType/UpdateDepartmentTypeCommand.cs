using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DepartmentTypes.Commands.UpdateDepartmentType 
{
    public class UpdateDepartmentTypeCommand : IRequest<Response<int>>
    {
        public int DepartmentTypeId { get; set; }
        public string DepartmentTypeName { get; set; }  

        public class UpdateDepartmentTypeCommandHandler : IRequestHandler<UpdateDepartmentTypeCommand, Response<int>>
        {
            private readonly IDepartmentTypeRepositoryAsync _departmentTypeRepository; 
            public UpdateDepartmentTypeCommandHandler(IDepartmentTypeRepositoryAsync departmentTypeRepository)
            {
                _departmentTypeRepository = departmentTypeRepository;
            }
            public async Task<Response<int>> Handle(UpdateDepartmentTypeCommand command, CancellationToken cancellationToken)
            {
                var departmentType = await _departmentTypeRepository.GetByIdAsync(command.DepartmentTypeId);

                if (departmentType == null)
                {
                    throw new ApiException($"Department Type Not Found.");
                }
                else
                {
                    departmentType.DepartmentTypeId = command.DepartmentTypeId;
                    departmentType.DepartmentTypeName = command.DepartmentTypeName;
                    await _departmentTypeRepository.UpdateAsync(departmentType);
                    return new Response<int>(departmentType.DepartmentTypeId);
                }
            }
        }
    }
}
