using AutoMapper;
using Todo.Application.Models.Database;
using Todo.Domain.Entities;

namespace Todo.Application.Mappings
{
    public class TodoProfile: Profile
    {
        public TodoProfile()
        {
            CreateMap<ModelTodo, TodoEntity>();

        }
    }

}
