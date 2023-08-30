using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.DAL.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {

        IQueryable<T> Items { get; }

        T Get(int id);


        T Add(T item);

        Task<T> AddAsync(T item);

        void Update(T item);

        Task UpdateAsync(T item);

        void Remove(int id);

        Task RemoveAsync(int id);
    }
}
