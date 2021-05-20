using APIs.ViewModels;
using AutoMapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIs.AutoMapperConfig
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, VmBook>();
        }
    }
}
