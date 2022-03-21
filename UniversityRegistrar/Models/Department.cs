using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace UniversityRegistrar.Models
{
  public class Department
  {
    public Department()
    {
      this.Courses = new HashSet<Course>();
    }
    public int DepartmentId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Course> Courses { get; set; }
  }
}