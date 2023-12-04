using System.ComponentModel.DataAnnotations;

namespace _2FA.Dtos
{
    public class MessageRessourceDto
    {
        [Required]
        public string Phone { get; set; }
    }
}
