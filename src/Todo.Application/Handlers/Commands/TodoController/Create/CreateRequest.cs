using System.ComponentModel.DataAnnotations;
using Todo.Application.Models.Database;

namespace Todo.Application.Handlers.Commands.TodoController.Create
{

    public class CreateRequest
    {
        public string Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; } = false;
        public string RecordStatus { get; set; }

    }

}
