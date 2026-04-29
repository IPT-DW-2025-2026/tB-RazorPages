using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
    
    /// <summary>
    /// campo auxiliar usado para popular TuitionFee 
    /// </summary>
    [NotMapped]
    [Display(Name = "Valor da Propina")]
    [RegularExpression("[0-9]{1,6}(.|,)[0-9]{1,2}", 
        ErrorMessage = "O {0} deve apenas conter um ponto ou vírgula entre a unidade e os decimais. " +
                       "O formato deve seguir nnnnnn,dd ou nnnnnn.dd")]
    public string TuitionFeeAux { get; set; }
    
    [Display(Name = "Data de Matrícula")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date)]
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
    
    /*
     * Relacionamento 1-N
     * Degree - Student
     */
    [ForeignKey(nameof(Degree))]
    public int DegreeFk { get; set; }
    
    [ValidateNever]
    public Degree Degree { get; set; }
    
    /*
     * Relacionamento N-M, com especificação da tabela intermédia
     * Student - Course(UC)
     */
    public ICollection<Registration> Registrations { get; set; } = [];
}