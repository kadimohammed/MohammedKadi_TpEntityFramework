using System.ComponentModel.DataAnnotations;

namespace MohammedKadi_TpEntityFramework.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        [MinLength(10)]
        public string Description { get; set; }
    }


}
