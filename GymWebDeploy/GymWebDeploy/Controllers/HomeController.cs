using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    public class HomeController : Controller, IGenericController<Empleado>
    {
        LoginController status = new LoginController();
        public JsonResult Get()
        {
            throw new System.NotImplementedException();
        }

        public ActionResult Index()
        {
            
            if (!status.checkSession())
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View(); 
            }
            
        }

        public JsonResult Save(Empleado data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(Empleado data)
        {
            throw new System.NotImplementedException();
        }
    }
}