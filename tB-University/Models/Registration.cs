using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace tB_University.Models;

[PrimaryKey(nameof(StudentFk), nameof(CourseFk))]
public class Registration
{
    
    [Display(Name = "Data de inscrição")]
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
    
    /*
     * Relacionamento 1-N
     * Aluno - Registration
     */
    
    [ForeignKey(nameof(Student))]
    public int StudentFk { get; set; }
    [ValidateNever]
    public Student Student { get; set; }
    
    /*
     * Relacionamento 1-N
     * Course(UC) - Registration
     */
    [ForeignKey(nameof(Course))]
    public int CourseFk { get; set; }
    [ValidateNever]
    public Course Course { get; set; }
}