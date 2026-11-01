using AutoMapper;
using Todo.Application.Models.Database;
using Todo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Mappings
{
    public class PersonProfile: Profile
    {
        public PersonProfile()
        {
            CreateMap<ModelPerson, Person>();
            CreateMap<Person, ModelPerson>();
        }
    }

}
