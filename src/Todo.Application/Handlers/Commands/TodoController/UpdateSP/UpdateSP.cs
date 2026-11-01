using AutoMapper;
using Todo.Application.Handlers.Commands.PersonController.Update;
using Todo.Application.Interfaces.Repositories;
using Todo.Application.Models.Common;
using Todo.Common.Helpers;
using MediatR;
using Reec.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Handlers.Commands.PersonController.UpdateSP
{
    public class UpdateSP : IRequest<ReecMessage>
    {
        public UpdateSPRequest Model { get; }
        public UpdateSP(UpdateSPRequest model)
        {
            Model = model;
        }

        public class UpdateSPHandler : IRequestHandler<UpdateSP, ReecMessage>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly ITodoRepository _todoRepository;

            public UpdateSPHandler(IUnitOfWork unitOfWork, IMapper mapper, ITodoRepository todoRepository)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _todoRepository = todoRepository;
            }
            public async Task<ReecMessage> Handle(UpdateSP request, CancellationToken cancellationToken)
            {
                //await _todoRepository.CreateAndUpdateByStoredProcedure(request.Model.Person);
                //var message = new ReecMessage(ReecEnums.Category.OK, ConstantMessage.CreateMessage);
                return null;
            }
        }
    }
}
