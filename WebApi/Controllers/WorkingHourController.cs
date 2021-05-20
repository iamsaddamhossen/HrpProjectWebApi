using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.DepartmentTypes.Commands;
using Application.Features.WorkingHours.Commands.CreateWorkingHour;
using Application.Features.WorkingHours.Commands.DeleteWorkingHourById;
using Application.Features.WorkingHours.Commands.UpdateWorkingHour;
using Application.Features.WorkingHours.Queries.GetAllWorkingHours;
using Application.Features.WorkingHours.Queries.GetWorkingHourById;
using Application.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    //[ApiVersion("1.0")]
    public class WorkingHourController : BaseApiController
    {
        //// GET: api/<controller>
        //[AllowAnonymous]
        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] GetAllDepartmentTypesParameter filter)
        //{

        //    return Ok(await Mediator.Send(new GetAllDepartmentTypesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        //}

        // GET: api/<controller>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllWorkingHoursQuery())); 
        }

        // GET api/<controller>/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetWorkingHourByIdQuery { WorkingHourId = id }));
        }

        // POST api/<controller>
        [AllowAnonymous]
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Post(CreateWorkingHourCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [AllowAnonymous]
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Put(int id, UpdateWorkingHourCommand command)
        {
            if (id != command.WorkingHourId)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [AllowAnonymous]
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteWorkingHourByIdCommand { WorkingHourById = id }));
        }

    }
}
