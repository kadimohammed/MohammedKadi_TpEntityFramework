using Microsoft.EntityFrameworkCore;
using MohammedKadi_TpEntityFramework.Data;
using MohammedKadi_TpEntityFramework.Repositories.Interfaces;

namespace MohammedKadi_TpEntityFramework.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _entities;

        public Repository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public void Add(T model)
        {
            _entities.Add(model);
        }

        public void Delete(T model)
        {
            _entities.Remove(model);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public T GetById(int id)
        {
            return _entities.Find(id);
        }

        public void Update(T model)
        {
            _entities.Update(model);
        }
    }
}
