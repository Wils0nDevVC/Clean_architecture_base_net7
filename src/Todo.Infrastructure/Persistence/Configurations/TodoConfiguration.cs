using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Infrastructure.Persistence.Configurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<TodoEntity>
    {

        public void Configure(EntityTypeBuilder<TodoEntity> builder)
        {
            builder.ToTable("TodoEntity");
            builder.HasKey(t => t.Id);

        }
    }
}
