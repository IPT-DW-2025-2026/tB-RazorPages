using System.ComponentModel.DataAnnotations;

namespace tB_University.Models;

public class MyUser
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Nome")]
    [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
    [StringLength(50, ErrorMessage = "O tamanho máximo para o {0} é {1} caracteres")]
    public string Name { get; set; } = string.Empty;
    
    [Display(Name = "Data de Nascimento")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    [Display(Name = "Telemóvel")]
    [StringLength(19)]
    [RegularExpression("([+]|00)?[0-9]{6,17}", ErrorMessage = "O {0} só pode conter dígitos. No mínimo 6")]
    public string? CellPhone { get; set; }
    

    /// <summary>
    /// atributo para usar como FK entre a tabela dos MyUser
    ///     e a tabela de Autenticacao do Identity
    /// </summary>
    [StringLength(50)]
    public string UserId { get; set; } = null!;
}