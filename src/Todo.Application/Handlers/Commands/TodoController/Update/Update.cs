using AutoMapper;
using Todo.Application.Interfaces.Repositories;
using Todo.Application.Models;
using Todo.Application.Models.Common;
using Todo.Common.Helpers;
using Todo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Reec.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Handlers.Commands.TodoController.Update
{
    public class Update : IRequest<ReecMessage>
    {
        public UpdateRequest Model { get; }
        public Update(UpdateRequest model)
        {
            Model = model;
        }

        public class UpdateHandler : IRequestHandler<Update, ReecMessage>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public UpdateHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }   
            public async Task<ReecMessage> Handle(Update request, CancellationToken cancellationToken)
            {

                var isExists = _unitOfWork.Todos.AsNoTracking().Any(t => t.Id == request.Model.Id);
                if (!isExists)
                    throw new ReecException(ReecEnums.Category.Warning, $"No exíste el Todo para actualizar.");


                var todoEntity = new TodoEntity()
                {
                    Id = request.Model.Id,
                    Name = request.Model.Name,
                    Description = request.Model.Description,
                    Status = request.Model.Status,
                    RecordStatus = request.Model.RecordStatus,


                };



                var entry = _unitOfWork.Todos.Update(todoEntity);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                var result = _mapper.Map<TodoEntity>(todoEntity);


                var message = new ReecMessage(ReecEnums.Category.OK, ConstantMessage.UpdateMessage);
                return message;


            }
        }
    }

}
