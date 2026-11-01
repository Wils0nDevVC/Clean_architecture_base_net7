using AutoMapper;
using Todo.Application.Interfaces.Repositories;
using Todo.Application.Models.Database;
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
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;

namespace Todo.Application.Handlers.Queries.TodoController.FindAll
{
    public class FindAll : IRequest<Pagination<TodoEntity>>
    {
        int page ;
        int limit ;
        public FindAll(int _page = 1 , int _limit = 10 ) {
            this.page = _page;
            this.limit = _limit;
        }
        public class FindAllHandler : IRequestHandler<FindAll, Pagination<TodoEntity>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public FindAllHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }


            public async Task<Pagination<TodoEntity>> Handle(FindAll request, CancellationToken cancellationToken)
            {
                var listEntity = await _unitOfWork.Todos.AsNoTracking().Where(x => x.RecordStatus == "A").OrderBy(x => x.Id).Skip((request.page - 1) * request.limit ).Take(request.limit).ToListAsync();
                                                  

                if (listEntity == null || listEntity.Count == 0)
                    throw new ReecException(ReecEnums.Category.PartialContent, ConstantMessage.NotRecords);

                var pagination = new Pagination<TodoEntity>(listEntity, listEntity.Count, request.page, request.limit);


                return  pagination ;
            }
        }
    }


}
