using MohammedKadi_TpEntityFramework.Data;
using MohammedKadi_TpEntityFramework.Entities;
using MohammedKadi_TpEntityFramework.Repositories.Interfaces;

namespace MohammedKadi_TpEntityFramework.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IRepository<Student> StudentRepository { get; set; }
        public IRepository<Teacher> TeacherRepository { get; set; }
        public IRepository<Class> ClassRepository { get; set; }
        public IRepository<Enrollment> EnrollmentRepository { get; set; }
        public IRepository<Subject> SubjectRepository { get; set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            StudentRepository = new Repository<Student>(context);
            TeacherRepository = new Repository<Teacher>(context);
            ClassRepository = new Repository<Class>(context);
            EnrollmentRepository = new Repository<Enrollment>(context);
            SubjectRepository = new Repository<Subject>(context);
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
