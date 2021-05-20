using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Services.Interfaces;
using AutoMapper;
using APIs.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMapper Mapper;
        private readonly IBookService BookService;
        public BooksController(IMapper Mapper,IBookService BookService)
        {
            this.Mapper = Mapper;
            this.BookService = BookService;
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public List<VmBook> GetAll()
        {
            return Mapper.Map<List<VmBook>>(BookService.GetAll());
        }
    }
}
