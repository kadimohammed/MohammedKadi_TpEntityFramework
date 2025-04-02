using System.ComponentModel.DataAnnotations;

namespace MohammedKadi_TpEntityFramework.Entities
{
    public class Student : Person
    {
        [Required]
        public int StudentNumber { get; set; }
    }


}
