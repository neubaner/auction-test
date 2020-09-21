using System.ComponentModel.DataAnnotations;

namespace totvs_test.Dtos
{
    public class CreateUserDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}