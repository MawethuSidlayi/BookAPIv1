using BookAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAPI.Domain.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T entity);
        Task Delete(int id);
    }
}
