using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PollItApp.Models
{
    public class Poll
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Q1 { get; set; }
        public int Q2 { get; set; }

        [Required]
        [MaxLength(300)]
        public string Q10 { get; set; }
    }
}
