using System.ComponentModel.DataAnnotations;

namespace ValidationAttributesTest.Models
{
    public class Student
    {
        //[Required]
        [Required(ErrorMessage = "이름을 작성하세요")]
        [StringLength(15, MinimumLength =2, 
            ErrorMessage="이름을 최소 2자이상 작성해주세요.")]
        public string Name { get; set; }
    }
}
