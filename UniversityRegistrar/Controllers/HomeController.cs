using Microsoft.AspNetCore.Mvc;

namespace UniversityRegistrar.Controllers
{
  [Route("/")]
  public class HomeController : Controller
  {
    [HttpGet]
    public ActionResult Index()
    {
      return View();
    }
  }
}