using System.ComponentModel.DataAnnotations;

namespace MohammedKadi_TpEntityFramework.Entities
{
    public class Class
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Range(1, 15)]
        public int Level { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;
    }


}
