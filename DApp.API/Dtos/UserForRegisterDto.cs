using System.ComponentModel.DataAnnotations;

namespace DApp.API.Dtos
{
  public class UserForRegisterDto
  {
    [Required]
    public string Username { get; set; }

    [Required]
    [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password beteen4 and 8 characters")]
    public string Password { get; set; }
  }
}