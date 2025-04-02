using MohammedKadi_TpEntityFramework.Data;
using MohammedKadi_TpEntityFramework.Repositories.Interfaces;

namespace MohammedKadi_TpEntityFramework.Repositories
{
    public class UnitOfWork<T> : IDisposable, IUnitOfWork<T> where T : class
    {
        protected readonly AppDbContext _context;
        public IRepository<T> Repository { get; set; }

        public UnitOfWork(AppDbContext context, IRepository<T> repository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
