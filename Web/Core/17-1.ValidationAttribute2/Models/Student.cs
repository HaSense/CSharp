using System.ComponentModel.DataAnnotations;

namespace ValidationAttribute01.Models
{
    public class Student
    {
        [Display(Name = "이름을 입력하세요:")]
        //[Required]
        [Required(ErrorMessage = "이름란에 이름이 빠졌습니다.")]
        //[MaxLength(15)]
        [StringLength(15, MinimumLength =2,
            ErrorMessage ="이름은 두자 이상 작성이 가능합니다.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email을 적어주세요..")]
        //[EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", ErrorMessage ="이메일 패턴이 맞지 않습니다.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "나이를 적어주세요..")]
        [Range(20, 70, ErrorMessage ="20-70세까지 작성할 수 있습니다.")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "패스워드를 적어주세요.")]
        [RegularExpression(@"(?=.*[a-zA-Z])(?=.*[0-9]).{8,25}$",ErrorMessage ="영문자로 대소문자와 숫자조합으로 8자리이상")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "패스워드 확인란을 채워주세요.")]
        [Compare("Password", ErrorMessage ="패스워드와 동일해야 합니다.")]
        [Display(Name = "확인 패스워드를 작성하세요.")]
        public string ConfirmPassword {  get; set; }
        
        [Required(ErrorMessage = "전화번호가 필요합니다.")]
        [RegularExpression(@"^\d{3}-\d{3,4}-\d{4}$", ErrorMessage = "전화번호 패턴이 맞지 않습니다.")]
        public string Hp { get; set; }

        
        [Required(ErrorMessage = "URL 주소가 필요합니다.")]
        [Url(ErrorMessage ="정확한 주소를 작성하세요.")]
        public string WebsiteURL { get; set; }

    }
}
