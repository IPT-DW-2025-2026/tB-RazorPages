using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace tB_University.Models;

public class Student : MyUser
{
    [DisplayName("Número de estudante")]
    [Required(ErrorMessage = "O {0} é obrigatório")]
    public int StudentNumber { get; set; }
    
    [Display(Name = "Propina")]
    [Precision(8,2)]
    public decimal TuitionFee { get; set; }
    
    [Display(Name = "Data de Matrícula")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date)]
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
}