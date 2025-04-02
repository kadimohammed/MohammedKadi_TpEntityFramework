
namespace MohammedKadi_TpEntityFramework.Repositories.Interfaces
{
    public  interface IUnitOfWork<T> where T : class
    {
        IRepository<T> Repository { get; set; }
        Task<int> SaveChangesAsync();
    }
}
