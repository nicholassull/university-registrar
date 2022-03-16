using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UniversityRegistrar.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace UniversityRegistrar.Controllers
{
  public class StudentsController : Controller
  {
    private readonly UniversityRegistrarContext _db;
    public StudentsController(UniversityRegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Students.ToList());
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Student student)
    {
      _db.Students.Add(student);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details (int id)
    {
      Student thisStudent = _db.Students
      .Include(student => student.JoinEntities)
      .ThenInclude(join => join.Course)
      .FirstOrDefault(student => student.StudentId == id);
      return View(thisStudent);
    }
    // public ActionResult Edit (int id)
    // {
    //   var thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
    //   // add ViewBag select list for courses
    // }
  }
}