using Application.Filters;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DepartmentTypes.Queries.GetAllDepartmentTypes 
{
    //public class GetAllDepartmentTypesQuery : IRequest<PagedResponse<IEnumerable<GetAllDepartmentTypesViewModel>>>
    //{
    //    public int PageNumber { get; set; }
    //    public int PageSize { get; set; }
    //}

    public class GetAllDepartmentTypesQuery : IRequest<PagedResponse<IEnumerable<GetAllDepartmentTypesViewModel>>>
    {
        //public int PageNumber { get; set; }
        //public int PageSize { get; set; }
    }

    public class GetAllDepartmentTypesQueryHandler : IRequestHandler<GetAllDepartmentTypesQuery, PagedResponse<IEnumerable<GetAllDepartmentTypesViewModel>>>
    {
        private readonly IDepartmentTypeRepositoryAsync _departmentTypeRepository; 
        private readonly IMapper _mapper;
        public GetAllDepartmentTypesQueryHandler(IDepartmentTypeRepositoryAsync departmentTypeRepository, IMapper mapper) 
        {
            _departmentTypeRepository = departmentTypeRepository;
            _mapper = mapper;
        }

        //public async Task<PagedResponse<IEnumerable<GetAllDepartmentTypesViewModel>>> Handle(GetAllDepartmentTypesQuery request, CancellationToken cancellationToken)
        //{
        //    var validFilter = _mapper.Map<GetAllDepartmentTypesParameter>(request);
        //    var departmentType = await _departmentTypeRepository.GetPagedReponseAsync(validFilter.PageNumber,validFilter.PageSize);
        //    var departmentTypeViewModel = _mapper.Map<IEnumerable<GetAllDepartmentTypesViewModel>>(departmentType);
        //    return new PagedResponse<IEnumerable<GetAllDepartmentTypesViewModel>>(departmentTypeViewModel, validFilter.PageNumber, validFilter.PageSize);           
        //}

        public async Task<PagedResponse<IEnumerable<GetAllDepartmentTypesViewModel>>> Handle(GetAllDepartmentTypesQuery request, CancellationToken cancellationToken)
        {
            //var validFilter = _mapper.Map<GetAllDepartmentTypesParameter>(request);
            var departmentType = await _departmentTypeRepository.GetAllAsync();
            var departmentTypeViewModel = _mapper.Map<IEnumerable<GetAllDepartmentTypesViewModel>>(departmentType);
            return new PagedResponse<IEnumerable<GetAllDepartmentTypesViewModel>>(departmentTypeViewModel);
        }
    }
}
