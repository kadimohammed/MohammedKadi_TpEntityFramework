using System.ComponentModel.DataAnnotations;

namespace MohammedKadi_TpEntityFramework.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
        public Student Student { get; set; } = null!;
        public Class Class { get; set; } = null!;
        public int StudentId { get; set; }
        public int ClassId { get; set; }
    }

}
