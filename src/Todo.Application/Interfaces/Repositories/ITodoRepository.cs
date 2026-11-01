
using Todo.Application.Handlers.Commands.TodoController.CreateSP;

namespace Todo.Application.Interfaces.Repositories
{
    public interface ITodoRepository
    {
        Task<int> CreateStoredProcedure(CreateSPRequest todoEntity);
    }
}
