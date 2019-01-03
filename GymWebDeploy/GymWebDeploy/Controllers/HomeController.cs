using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.HttpMethod == "POST")
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View(); 
            }
            
        }
    }
}