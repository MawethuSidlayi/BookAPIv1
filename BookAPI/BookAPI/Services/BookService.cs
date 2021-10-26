using BookAPI.Domain.Interfaces;
using BookAPI.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookAPI.Services
{
    public class BookService: ControllerBase, IBookService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IBookRepository bookRepository;
        private readonly IRepository<BookSubscriptions> subscriptionsRepository;


        public BookService(IBookRepository bookRepository, IRepository<BookSubscriptions> subscriptionsRepository, UserManager<IdentityUser> userManager)
        {
            this.bookRepository = bookRepository;
            this.subscriptionsRepository = subscriptionsRepository;
            this.userManager = userManager;
        }

        public async Task AddBook(Book book)
        {
             await bookRepository.Insert(book);
        }

        public async Task SubscribeToBook(int book_id)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await subscriptionsRepository.Insert(new BookSubscriptions { Book_Id = book_id, User_Id = userId, CreatedAt = DateTime.Now });
        }

        public async Task<IEnumerable<Book>> GetBookSubscriptions()
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var subscriptions = (await subscriptionsRepository.GetAll()).Where(r => r.User_Id == userId);
            
            var books = await bookRepository.GetAll();

            var result = (from s in subscriptions
                          join b in books on s.Book_Id equals b.Id
                          select new Book{ 
                              Id = b.Id,
                              Name = b.Name,
                              PurchasePrice = b.PurchasePrice,
                              Text= b.Text
                          });


            return result;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
           return await bookRepository.GetAll();
        }
    }
}
