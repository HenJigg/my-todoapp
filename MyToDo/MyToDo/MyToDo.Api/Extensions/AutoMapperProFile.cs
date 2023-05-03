using AutoMapper.Configuration;
using Detection_System.Api.Context;
using Detection_System.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detection_System.Api.Extensions
{
    public class AutoMapperProFile : MapperConfigurationExpression
    {
        public AutoMapperProFile()
        {
            CreateMap<ToDo, ToDoDto>().ReverseMap();
            CreateMap<Memo, MemoDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
