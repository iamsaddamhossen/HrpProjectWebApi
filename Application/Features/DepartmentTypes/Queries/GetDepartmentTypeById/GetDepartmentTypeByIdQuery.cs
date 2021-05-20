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

namespace Application.Features.DepartmentTypes.Queries.GetDepartmentTypeById 
{
    public class GetDepartmentTypeByIdQuery : IRequest<Response<DepartmentType>>
    {
        public int DepartmentTypeId { get; set; } 
        public class GetDepartmentTypeByIdQueryHandler : IRequestHandler<GetDepartmentTypeByIdQuery, Response<DepartmentType>>
        {
            private readonly IDepartmentTypeRepositoryAsync _departmentTypeRepository; 
            public GetDepartmentTypeByIdQueryHandler(IDepartmentTypeRepositoryAsync departmentTypeRepository) 
            {
                _departmentTypeRepository = departmentTypeRepository;
            }
            public async Task<Response<DepartmentType>> Handle(GetDepartmentTypeByIdQuery query, CancellationToken cancellationToken)
            {
                var departmentType = await _departmentTypeRepository.GetByIdAsync(query.DepartmentTypeId);
                if (departmentType == null) throw new ApiException($"Department Type Not Found.");
                return new Response<DepartmentType>(departmentType);
            }
        }
    }
}
