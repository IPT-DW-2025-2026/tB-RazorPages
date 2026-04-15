using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace tB_University.Models;

/// <summary>
/// Esta classe implementa a lógica por detrás das Unidades Curriculares
/// </summary>
public class Course
{
    [Key]
    public int Id { get; set; }
    
    [Display(Name = "Unidade Curricular")]
    [Required(ErrorMessage = "A {0} é de preenchimento obrigatório")]
    [StringLength(30, ErrorMessage = "O tamanho máximo para o nome da {0} é de {1} caracteres")]
    public string Name { get; set; } = string.Empty;
    
    [Display(Name = "Ano")]
    public int? CurricularYear { get; set; }
    
    [Display(Name = "Semestre")]
    public int? Semester { get; set; }
    
    /*
     * Relacionamento 1-N
     * Degree - Course(UC)
     */
    [ForeignKey(nameof(Degree))]
    [Display(Name = "Curso")]
    public int DegreeFk { get; set; }
    [ValidateNever]
    public Degree Degree { get; set; }
    
    /* 
    * Relacionamento N-M
    * Course(UC) - Teacher
    */ 
    public ICollection<Teacher> Teachers { get; set; }  = [];
    
    /*
     * Relacionamento N-M, com especificação da tabela intermédia
     * Student - Course(UC)
     */
    public ICollection<Registration> Registrations { get; set; } = [];
}