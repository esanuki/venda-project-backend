using Microsoft.EntityFrameworkCore;
using ProjectVenda.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVenda.Core.Data
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly ProjectVendaDbContext _context;
        private readonly DbSet<T> _dbSet;

        protected Repository(ProjectVendaDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.FirstAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task Save(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);

            await Task.CompletedTask;
        }
        public async Task Delete(Guid id)
        {
            var entity = await GetById(id);

            if (entity is null) return;

            _dbSet.Remove(entity);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
