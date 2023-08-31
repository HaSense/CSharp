using System.ComponentModel.DataAnnotations;

namespace BasicCRUD.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Hp { get; set; }
    }
}
