using System.ComponentModel.DataAnnotations;

public class ForgotPasswordModel
{
    [Required]
    public string Email { get; set; }
}
