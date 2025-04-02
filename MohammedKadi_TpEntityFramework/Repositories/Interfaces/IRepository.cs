using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohammedKadi_TpEntityFramework.Repositories.Interfaces
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : class
    {
        void Add(T model);
        void Update(T model);
        void Delete(T model);
    }
}
