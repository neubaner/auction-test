using System.ComponentModel.DataAnnotations;

namespace totvs_test.Dtos
{
    public class CreateTokenDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}