using BookAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Domain.Interfaces
{
    public interface IBookRepository: IRepository<Book>
    {
        Task Update(Book book);
    }
}
