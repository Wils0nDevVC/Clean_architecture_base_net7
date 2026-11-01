
namespace Todo.Common.Helpers
{
    public static class ConstantDB
    {
        public static class ConnectionStringDB
        {
            public const string TodoDb = "DEV_STANDAR";
        }

        public static class ConstantStoreProcedure
        {

            public const string ListTodo = "USP_LIST_Todo";
            public const string RegisterTodo = "USP_REGISTER_Todo";
            public const string GetByIdTodo = "USP_GET_ById_Todo";
            public const string DeleteTodo = "USP_DELETE_Todo";
            public const string UpdateTodo = "USP_UPDATE_Todo";

        }

        
    }
}