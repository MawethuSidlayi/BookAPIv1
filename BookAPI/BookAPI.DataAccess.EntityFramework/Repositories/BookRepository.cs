using BookAPI.Domain.Interfaces;
using BookAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI
{
    public class BookRepository: Repository<Book>, IBookRepository
    {
        public BookRepository(BookContext context):base(context)
        {
        }

        public async Task Update(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            context.Entry(book).State = EntityState.Modified;
            await context.SaveChangesAsync();

        }
    }
}
