using System.ComponentModel.DataAnnotations;

namespace MohammedKadi_TpEntityFramework.Entities
{
    public class Class
    {
        public virtual int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public virtual string Name { get; set; }
        [Range(1, 15)]
        public virtual int Level { get; set; }
        public virtual int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; } = null!;
    }


}
