using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KognitBackEndTeste.Models
{
    public class Wallet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }

        [Required]
        public decimal CurrentValue { get; set; }

        [Required]
        public string Bank { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
