using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repo1.Model
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int eId { get; set; }
        public string? eName { get; set; } 

        public string? eEmail { get; set; }
        public string? eMobile { get; set; }
    }
}
