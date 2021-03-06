using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityRegistrar.Models{
  public class Course
  {
    public int CourseId {get; set;}

    [Required]
    [DisplayName("Input Course ID Label")]
    public string Label {get; set;}

    [DisplayName("Course Name")]
    public string CourseName {get; set;}

    public string Description {get; set;}

    public virtual ICollection<StudentCourse> JoinEntities {get; set;}

    public Course()
    {
      JoinEntities = new HashSet<StudentCourse>();
    }
  }
}