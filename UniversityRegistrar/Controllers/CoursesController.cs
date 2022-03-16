using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityRegistrar.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversityRegistrar.Controllers
{
  public class CoursesController : Controller
  {
    private readonly UniversityRegistrarContext _db;
    public CoursesController(UniversityRegistrarContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View(_db.Courses.ToList());
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Course course)
    {
      _db.Courses.Add(course);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Course thisCourse = _db.Courses
      .Include(course => course.JoinEntities)
      .ThenInclude(join => join.Student)
      .FirstOrDefault(course => course.CourseId == id);
      return View(thisCourse);
    }
  }
}
