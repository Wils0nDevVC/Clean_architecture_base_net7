using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Models.Database;

namespace Todo.Application.Handlers.Queries.TodoController.FindId
{
    public class FindIdResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; } = false;

    }


}
