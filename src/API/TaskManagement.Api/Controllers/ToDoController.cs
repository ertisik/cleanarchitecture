using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Tasks.Commands;
using TaskManagement.Application.Features.Tasks.Queries.ToDoListByDate;

namespace TaskManagement.Api.Controllers
{
    [ApiController]
    [Route("todo")]
    public class ToDoController : ControllerBase
    {
        private readonly IMediator mediator;

        public ToDoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("getlist")]
        public async Task<ActionResult<ToDoListDto>> GetToDos(DateTime date, int page, int size)
        {
            ToDoListByDateQuery toDoListByDateQuery = new ToDoListByDateQuery
            {
                Date = date,
                Page = page,
                Size = size
            };

            var response = await mediator.Send(toDoListByDateQuery);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CreateToDoCommandResponse>> Create([FromBody] CreateToDoCommand model)
        {
            var response = await mediator.Send(model);

            return Ok(response);
        }
    }
}
