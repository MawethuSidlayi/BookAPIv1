using BookAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Services
{
    public interface IBookService
    {
        Task AddBook(Book book);
        Task SubscribeToBook(int book_id);

        Task<IEnumerable<Book>> GetBookSubscriptions();

        Task<IEnumerable<Book>> GetAllBooks();
    }
}
