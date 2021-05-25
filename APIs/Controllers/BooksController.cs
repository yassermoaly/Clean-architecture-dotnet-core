using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Models.ViewModels;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;
        public BooksController(IMapper Mapper,IBookService BookService)
        {
            this._mapper = Mapper;
            this._bookService = BookService;
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<List<VmBook>> GetAll()
        {
            return _mapper.Map<List<VmBook>>(await _bookService.GetAll());
        }
    }
}
