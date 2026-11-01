using Todo.Application.Handlers.Commands.TodoController.Create;
using Todo.Application.Handlers.Commands.TodoController.CreateSP;
using Todo.Application.Handlers.Commands.TodoController.Delete;
using Todo.Application.Handlers.Commands.PersonController.Update;
using Todo.Application.Handlers.Commands.PersonController.UpdateSP;
using Todo.Application.Handlers.Queries.TodoController.FindAll;
using Todo.Application.Handlers.Queries.TodoController.FindId;
using static Todo.Common.Helpers.ConstantWebApiController;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application;
using Todo.Application.Handlers.Commands.TodoController.Update;

namespace Todo.Api.Controllers
{
    [Route(TodoEndpoint.prefixAapi)]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("FindAll")]
        public async Task<IActionResult> FindAll(int page = 1, int limit = 10)
        {
            var pagination = await _mediator.Send(new FindAll(page,limit));
            return Ok(new
            {
                PageIndex = pagination.PageIndex,
                TotalPages = pagination.TotalPages,
                TotalR = pagination.TotalR,
                Data = pagination
            });
        }

        [HttpGet("FindId/{idTodo}")]
        public async Task<IActionResult> FindId(Guid idTodo)
        {
            var result = await _mediator.Send(new FindId(idTodo));
            return Ok(result);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateRequest model)
        {

                var result = await _mediator.Send(new Create(model));
                return Ok(result);
            
  
        }

        [HttpPost("CreateSP")]
        public async Task<IActionResult> CreateSP(CreateSPRequest model)
        {
            var result = await _mediator.Send(new CreateSP(model));
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateRequest model)
        {
            var result = await _mediator.Send(new Update(model));
            return Ok(result);
        }

        

        [HttpDelete("Delete/{idTodo}")]
        public async Task<IActionResult> Delete(Guid idTodo)
        {
            var result = await _mediator.Send(new Delete(idTodo));
            return Ok(result);
        }
    }

}
