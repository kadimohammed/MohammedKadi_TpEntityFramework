
using MohammedKadi_TpEntityFramework.Entities;

namespace MohammedKadi_TpEntityFramework.Repositories.Interfaces
{
    public  interface IUnitOfWork
    {
        IRepository<Student> StudentRepository { get; set; }
        IRepository<Teacher> TeacherRepository { get; set; }
        IRepository<Class> ClassRepository { get; set; }
        IRepository<Enrollment> EnrollmentRepository { get; set; }
        IRepository<Subject> SubjectRepository { get; set; }
        Task<int> SaveChangesAsync();
    }
}
