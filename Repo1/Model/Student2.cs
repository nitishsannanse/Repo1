using System.ComponentModel.DataAnnotations;

namespace Repo1.Model
{
    public class Student2
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
