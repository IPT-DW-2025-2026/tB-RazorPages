using System.ComponentModel.DataAnnotations;

namespace tB_University.Models;

public class Registration
{
    [Key]
    public int Id { get; set; }
    
    [Display(Name = "Data de inscrição")]
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
}