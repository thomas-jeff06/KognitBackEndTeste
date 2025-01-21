using System.ComponentModel.DataAnnotations;

namespace KognitBackEndTeste.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birth { get; set; }

        [Required]
        [MaxLength(11)]
        public string SocialNumber { get; set; }
    }
}
