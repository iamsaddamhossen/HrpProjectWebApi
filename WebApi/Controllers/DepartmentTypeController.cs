using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.DepartmentTypes.Commands;
using Application.Features.DepartmentTypes.Commands.CreateDepartmentType;
using Application.Features.DepartmentTypes.Commands.DeleteDepartmentTypeById;
using Application.Features.DepartmentTypes.Commands.UpdateDepartmentType;
using Application.Features.DepartmentTypes.Queries.GetAllDepartmentTypes;
using Application.Features.DepartmentTypes.Queries.GetDepartmentTypeById;
using Application.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    //[ApiVersion("1.0")]
    public class DepartmentTypeController : BaseApiController 
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
            return Ok(await Mediator.Send(new GetAllDepartmentTypesQuery()));
        }

        // GET api/<controller>/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetDepartmentTypeByIdQuery { DepartmentTypeId = id }));
        }

        // POST api/<controller>
        [AllowAnonymous]
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Post(CreateDepartmentTypeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [AllowAnonymous]
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Put(int id, UpdateDepartmentTypeCommand command)
        {
            if (id != command.DepartmentTypeId)
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
            return Ok(await Mediator.Send(new DeleteDepartmentTypeByIdCommand { DepartmentTypeById = id }));
        }

    }
}
