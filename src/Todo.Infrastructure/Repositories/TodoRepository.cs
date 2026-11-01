using Todo.Application.Interfaces.Repositories;
using Todo.Common.Helpers;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Todo.Application.Handlers.Commands.TodoController.CreateSP;

namespace Todo.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IConfiguration _configuration;

        public TodoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<int> CreateStoredProcedure(CreateSPRequest TodoEntity)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString(ConstantDB.ConnectionStringDB.TodoDb)))
            {

                var parameters = new DynamicParameters();
                parameters.Add("@ParamId", Guid.NewGuid());
                parameters.Add("@ParamIName", TodoEntity.Name);
                parameters.Add("@ParamIDescription", TodoEntity.Description);
                parameters.Add("@ParamIStatus", TodoEntity.Status);
                parameters.Add("@ParamIRecordStatus", TodoEntity.RecordStatus);


                return await connection.ExecuteAsync(
                    sql: $"{ConstantDB.ConstantStoreProcedure.RegisterTodo}",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

       
    }
}
