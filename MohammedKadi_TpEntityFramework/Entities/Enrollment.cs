using System.ComponentModel.DataAnnotations;

namespace MohammedKadi_TpEntityFramework.Entities
{
    public class Enrollment
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual DateTime EnrollmentDate { get; set; }
        public virtual Student Student { get; set; } = null!;
        public virtual Class Class { get; set; } = null!;
        public virtual int StudentId { get; set; }
        public virtual int ClassId { get; set; }
    }

}
