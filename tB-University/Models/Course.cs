using System.ComponentModel.DataAnnotations;

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
    
}