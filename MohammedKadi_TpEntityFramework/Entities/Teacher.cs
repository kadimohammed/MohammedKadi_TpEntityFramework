using Castle.Components.DictionaryAdapter;
using System.ComponentModel.DataAnnotations;

namespace MohammedKadi_TpEntityFramework.Entities
{
    public class Teacher : Person
    {
        [Required]
        public virtual DateTime HireDate { get; set; }
        public virtual int? SubjectId { get; set; }
        public virtual Subject? Subject { get; set; }
    }


}
