using System.ComponentModel.DataAnnotations;

namespace MohammedKadi_TpEntityFramework.Entities
{
    public class Teacher : Person
    {
        [Required]
        public DateTime HireDate { get; set; }
        public int? SubjectId { get; set; }
        public Subject? Subject { get; set; }
    }


}
