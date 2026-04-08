using System.ComponentModel.DataAnnotations;

namespace tB_University.Models;

/// <summary>
/// Esta classe implementa a lógica por detrás de um curso, seja uma licenciatura/mestrado/tesp
/// </summary>
public class Degree
{
    [Key]
    public int Id { get; set; }
    
    [Display(Name = "Nome do Curso")]
    [Required(ErrorMessage = "O {0} é de preenchimento obrigatorio")]
    [StringLength(30, ErrorMessage = "O tamanho máximo para {0} é de {1} caracteres")]
    public string Name { get; set; } = string.Empty;
    
    [Display(Name="Logotipo do curso")]
    [StringLength(50)]
    public string? LogoType { get; set; } = string.Empty;
}