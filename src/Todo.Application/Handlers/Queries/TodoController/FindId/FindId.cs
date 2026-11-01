using AutoMapper;
using Todo.Application.Interfaces.Repositories;
using Todo.Application.Models;
using Todo.Application.Models.Database;
using Todo.Common.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Reec.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Entities;

namespace Todo.Application.Handlers.Queries.TodoController.FindId
{
    public class FindId : IRequest<FindIdResponse>
    {


        public Guid IdTodo { get; }

        public FindId(Guid idTodo)
        {
            IdTodo = idTodo;

        }

        public class FindIdHandler : IRequestHandler<FindId, FindIdResponse>
        {
   
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public FindIdHandler(IUnitOfWork unitOfWork, IMapper mapper
            
                )
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
               
            }

            public async Task<FindIdResponse> Handle(FindId request, CancellationToken cancellationToken)
            {

                var entity = await _unitOfWork.Todos.AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Id == request.IdTodo && x.RecordStatus == ConstantBase.Active);

                if (entity == null)
                    throw new ReecException(ReecEnums.Category.BusinessLogic, ConstantMessage.NotExists);

                var todo = _mapper.Map<TodoEntity>(entity);

                FindIdResponse result = new()
                {
                    Id= todo.Id,
                    Name= todo.Name,
                    Description= todo.Description,
                    Status= todo.Status,
                };

                return result;
            }
        }


    }

}
