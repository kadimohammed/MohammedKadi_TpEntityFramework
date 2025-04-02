namespace MohammedKadi_TpEntityFramework.Repositories.Interfaces
{
    public interface IReadOnlyRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
