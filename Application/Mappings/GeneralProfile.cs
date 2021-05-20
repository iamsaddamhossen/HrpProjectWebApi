using Application.Features.DepartmentTypes.Commands.CreateDepartmentType;
using Application.Features.DepartmentTypes.Queries.GetAllDepartmentTypes;

using Application.Features.WorkingHours.Commands.CreateWorkingHour;
using Application.Features.WorkingHours.Queries.GetAllWorkingHours;

using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {

            CreateMap<DepartmentType, GetAllDepartmentTypesViewModel>().ReverseMap();
            CreateMap<CreateDepartmentTypeCommand, DepartmentType>();
            CreateMap<GetAllDepartmentTypesQuery, GetAllDepartmentTypesParameter>();

            CreateMap<WorkingHour, GetAllWorkingHoursViewModel>().ReverseMap();
            CreateMap<CreateWorkingHourCommand, WorkingHour>();
            CreateMap<GetAllWorkingHoursQuery, GetAllWorkingHoursParameter>();

        }
    }
}
