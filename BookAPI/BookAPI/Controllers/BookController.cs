using BookAPI.Domain.Interfaces;
using BookAPI.Domain.Models;
using BookAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {


        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        [HttpPost]
        [Authorize]
        [Route("")]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            if(ModelState.IsValid)
            {
                await bookService.AddBook(book);
                return Ok();
            }
            return BadRequest();
        }

        [Authorize]
        [HttpPost]
        [Route("/Subscribe/{id}")]
        public async Task<IActionResult> SubscribeToBook([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                await bookService.SubscribeToBook(id);
                return Ok();
            }
            return BadRequest();
        }

        [Authorize]
        [HttpGet]
        [Route("/Subscriptions")]
        public async Task<IEnumerable<Book>> GetBookSubscriptions()
        {
            return await bookService.GetBookSubscriptions();
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await bookService.GetAllBooks();
        }

        [HttpDelete]
        [Route("{bookId}")]
        public async Task DeleteId(int bookId)
        {

        }
    }
}
