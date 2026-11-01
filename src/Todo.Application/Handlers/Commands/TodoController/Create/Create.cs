using AutoMapper;
using Todo.Application.Interfaces.Repositories;
using Todo.Application.Models.Common;
using Todo.Common.Helpers;
using Todo.Domain.Entities;
using MediatR;
using Reec.Inspection;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Application.Handlers.Commands.TodoController.Create
{
    public class Create : IRequest<ReecMessage>
    {
        public CreateRequest Model { get; }
        public Create(CreateRequest createRequest)
        {
            Model = createRequest;
        }

        public class CreateHandler : IRequestHandler<Create, ReecMessage>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public CreateHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<ReecMessage> Handle(Create request, CancellationToken cancellationToken)
            {


                var todoEntity = new TodoEntity()
                {
                    Name = request.Model.Name,
                    Description = request.Model.Description,
                    Status = request.Model.Status,
                    RecordStatus= request.Model.RecordStatus,


                };


                await _unitOfWork.Todos.CreateAsync(todoEntity);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                var result = _mapper.Map<TodoEntity>(todoEntity);

                var message = new ReecMessage(ReecEnums.Category.OK, ConstantMessage.CreateMessage);
                return message;
            }
        }
    }

}
