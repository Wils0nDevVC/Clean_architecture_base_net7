using AutoMapper;
using Todo.Application.Interfaces.Repositories;
using Todo.Common.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Reec.Inspection;


namespace Todo.Application.Handlers.Commands.TodoController.Delete
{
    public class Delete : IRequest<ReecMessage>
    {
        public Guid IdTodo { get; }
        public Delete(Guid idTodo)
        {
            IdTodo = idTodo;
        }

        public class DeleteHandler : IRequestHandler<Delete, ReecMessage>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public DeleteHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<ReecMessage> Handle(Delete request, CancellationToken cancellationToken)
            {

                var entity = await _unitOfWork.Todos.AsNoTracking().Where(p => p.Id == request.IdTodo).FirstOrDefaultAsync(cancellationToken);

                if (entity == null)
                    throw new ReecException(ReecEnums.Category.BusinessLogic, ConstantMessage.NotExists);



                entity.RecordStatus = ConstantBase.Inactive;
                _unitOfWork.Todos.Update(entity);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                var message = new ReecMessage(ReecEnums.Category.OK, ConstantMessage.DeleteMessage);
                return message;
            }

        }
    }

}

