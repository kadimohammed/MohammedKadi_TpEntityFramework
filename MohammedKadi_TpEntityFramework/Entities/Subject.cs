using System.ComponentModel.DataAnnotations;

namespace MohammedKadi_TpEntityFramework.Entities
{
    public class Subject
    {
        public virtual int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public virtual string Name { get; set; }
        [MaxLength(500)]
        [MinLength(10)]
        public virtual string Description { get; set; }
    }


}
