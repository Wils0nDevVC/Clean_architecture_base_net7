using Todo.Application.Models.Database;
using Todo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Todo.Common.Helpers.BaseEnums;

namespace Todo.Application.Handlers.Commands.TodoController.Update
{

    public class UpdateRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; } = false;
        public string RecordStatus { get; set; } 

    }

    


}
