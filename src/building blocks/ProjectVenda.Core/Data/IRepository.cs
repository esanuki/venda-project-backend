using ProjectVenda.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectVenda.Core.Data
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task Save(T entity);
        Task Update(T entity);
        Task Delete(Guid id);
    }
}
