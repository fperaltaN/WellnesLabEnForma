using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    interface IGenericController<T> where T : class
    {
        JsonResult Get();
        JsonResult Save(T data);
        JsonResult Update(T data);
    }
}
