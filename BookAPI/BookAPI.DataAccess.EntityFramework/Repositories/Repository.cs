using BookAPI.Domain.Interfaces;
using BookAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly BookContext context;
        private readonly DbSet<T> entities;

        public Repository(BookContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public async Task Delete(int id)
        {
            if (id == 0)
                throw new AggregateException();
            var entityToDelete = await entities.FindAsync(id);

            entities.Remove(entityToDelete);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            if (id == 0)
                throw new AggregateException();
            return await entities.FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            if (entity == null) 
                throw new  ArgumentNullException(nameof(entity));
            entities.Add(entity);
            await context.SaveChangesAsync();
        }

    }
}
