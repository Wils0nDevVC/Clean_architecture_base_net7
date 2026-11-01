using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Entities
{
    public class TodoEntity : BaseEntity, IGenerateEntity<TodoEntity>
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string RecordStatus { get; set; }
        public TodoEntity RecoverKey()
        {
            return new TodoEntity() {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                Status = this.Status,
                RecordStatus = this.RecordStatus

            };
        }

    }
}
