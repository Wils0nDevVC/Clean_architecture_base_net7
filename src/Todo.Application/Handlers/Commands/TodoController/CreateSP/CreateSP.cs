using AutoMapper;
using Todo.Application.Handlers.Commands.TodoController.Create;
using Todo.Application.Interfaces.Repositories;
using Todo.Application.Models.Common;
using Todo.Common.Helpers;
using MediatR;
using Reec.Inspection;

namespace Todo.Application.Handlers.Commands.TodoController.CreateSP
{
    public class CreateSP : IRequest<ReecMessage>
    {
        public CreateSPRequest Model { get; }
        public CreateSP(CreateSPRequest model)
        {
            Model = model;
        }

        public class CreateSPHandler : IRequestHandler<CreateSP, ReecMessage>
        {
            
            private readonly ITodoRepository _todoServices;

            public CreateSPHandler( ITodoRepository todoServices)
            {

                _todoServices = todoServices;
            }
            public async Task<ReecMessage> Handle(CreateSP request, CancellationToken cancellationToken)
            {

                await _todoServices.CreateStoredProcedure(request.Model);
                var message = new ReecMessage(ReecEnums.Category.OK, ConstantMessage.CreateMessage);
                return message;
            }
        }
    }
}
