using System.ComponentModel.DataAnnotations;

namespace BasicCRUDwithOracle18cEx.Models
{
    public class Student
    {
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "이름")]
        public string Name { get; set; }
        [Display(Name = "전화번호")]
        public string Hp { get; set; }
    }
}
