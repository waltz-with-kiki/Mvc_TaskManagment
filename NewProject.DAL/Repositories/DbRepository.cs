using Microsoft.EntityFrameworkCore;
using NewProject.DAL.Interfaces;
using NewProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.DAL.Repositories
{
    public class DbRepository<T> : IRepository<T> where T : Entity, new()
    {

        private readonly MonadaMech _db;
        private readonly DbSet<T> _Set;


        public DbRepository(MonadaMech db)
        {
            _db = db;
            _Set = db.Set<T>();
        }

        public virtual IQueryable<T> Items => _Set;

        public T Add(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            _db.SaveChanges();
            return item;
        }

        public async Task<T> AddAsync(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            await _db.SaveChangesAsync();
            return item;
        }

        public T Get(int id)
        {
           // return Items.SingleOrDefault(i => i.Id == id);
           return Items.FirstOrDefault(i => i.Id == id);
        }

        public async Task<T> GetAsync(int id) => await Items.SingleOrDefaultAsync(i => i.Id == id).ConfigureAwait(false);

       // public async Task<T> GetAsyn(int id) => await Items.FirstOrDefaultAsync(i => i.Id == id).ConfigureAwait(false);



        public void Remove(int id)
        {
            var item = _db.Set<T>().Where(i => i.Id == id).SingleOrDefault() ?? new T { Id = id};
            _db.Remove(item);
               // _db.Entry(item).State = EntityState.Deleted;
                _db.SaveChanges();
        }

        public async Task RemoveAsync(int id)
        {
            var item = await _db.Set<T>().Where(i => i.Id == id).SingleOrDefaultAsync() ?? new T { Id = id };
            _db.Remove(item);
            await _db.SaveChangesAsync();
        }

        public void Update(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public async Task UpdateAsync(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }


    public class ProjectDbRepository : DbRepository<Project>
    {
        public override IQueryable<Project> Items => base.Items.Include(item => item.Author).Include(item => item.ProjectUsers).Include(item => item.Exercises);

        public ProjectDbRepository(MonadaMech db) : base(db)
        {

        }

    }

}
