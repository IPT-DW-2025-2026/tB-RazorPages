namespace tB_University.Models;

public class Teacher : MyUser
{ 
    /* 
    * Relacionamento N-M
    * Course(UC) - Teacher
    */
    public ICollection<Course> Courses { get; set; } = [];
}