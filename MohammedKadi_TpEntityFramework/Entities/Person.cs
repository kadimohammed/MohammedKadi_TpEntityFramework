
using System.ComponentModel.DataAnnotations;

namespace MohammedKadi_TpEntityFramework.Entities
{
    public class Person
    {
        public int Id { get; set; }
        [MinLength(3)]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MinLength(3)]
        [MaxLength(100)]
        public string LastName { get; set; }
    }
}
