using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Location { get; set; }

    }
}
