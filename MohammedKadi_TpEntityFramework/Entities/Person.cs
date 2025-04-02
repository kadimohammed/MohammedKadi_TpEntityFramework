
using System.ComponentModel.DataAnnotations;

namespace MohammedKadi_TpEntityFramework.Entities
{
    public class Person
    {
        public virtual int Id { get; set; }
        [MinLength(3)]
        [MaxLength(100)]
        public virtual string FirstName { get; set; }
        [MinLength(3)]
        [MaxLength(100)]
        public virtual string LastName { get; set; }
    }
}
