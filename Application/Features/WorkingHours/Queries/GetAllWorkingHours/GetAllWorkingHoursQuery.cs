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

namespace Application.Features.WorkingHours.Queries.GetAllWorkingHours
{
    //public class GetAllDepartmentTypesQuery : IRequest<PagedResponse<IEnumerable<GetAllDepartmentTypesViewModel>>>
    //{
    //    public int PageNumber { get; set; }
    //    public int PageSize { get; set; }
    //}

    public class GetAllWorkingHoursQuery : IRequest<PagedResponse<IEnumerable<GetAllWorkingHoursViewModel>>>
    {
        //public int PageNumber { get; set; }
        //public int PageSize { get; set; }
    }

    public class GetAllWorkingHoursQueryHandler : IRequestHandler<GetAllWorkingHoursQuery, PagedResponse<IEnumerable<GetAllWorkingHoursViewModel>>>
    {
        private readonly IWorkingHourRepositoryAsync _workingHourRepository; 
        private readonly IMapper _mapper;
        public GetAllWorkingHoursQueryHandler(IWorkingHourRepositoryAsync workingHourRepository, IMapper mapper) 
        {
            _workingHourRepository = workingHourRepository;
            _mapper = mapper;
        }

        //public async Task<PagedResponse<IEnumerable<GetAllDepartmentTypesViewModel>>> Handle(GetAllDepartmentTypesQuery request, CancellationToken cancellationToken)
        //{
        //    var validFilter = _mapper.Map<GetAllDepartmentTypesParameter>(request);
        //    var departmentType = await _departmentTypeRepository.GetPagedReponseAsync(validFilter.PageNumber,validFilter.PageSize);
        //    var departmentTypeViewModel = _mapper.Map<IEnumerable<GetAllDepartmentTypesViewModel>>(departmentType);
        //    return new PagedResponse<IEnumerable<GetAllDepartmentTypesViewModel>>(departmentTypeViewModel, validFilter.PageNumber, validFilter.PageSize);           
        //}

        public async Task<PagedResponse<IEnumerable<GetAllWorkingHoursViewModel>>> Handle(GetAllWorkingHoursQuery request, CancellationToken cancellationToken)
        {
            //var validFilter = _mapper.Map<GetAllDepartmentTypesParameter>(request);
            var workingHour = await _workingHourRepository.GetAllAsync();
            var workingHourViewModel = _mapper.Map<IEnumerable<GetAllWorkingHoursViewModel>>(workingHour);
            return new PagedResponse<IEnumerable<GetAllWorkingHoursViewModel>>(workingHourViewModel);
        }
    }
}
