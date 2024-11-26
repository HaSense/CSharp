using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCLogin.Models
{
    public class LoginUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Number { get; set; }  // 사용자 고유 ID

        [Required]
        [StringLength(100)]
        public string UserId { get; set; }  // 사용자 이름

        [Required]
        public string UserPwd { get; set; }  // 비밀번호 값

    }
}
