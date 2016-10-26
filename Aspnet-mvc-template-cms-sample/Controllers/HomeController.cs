using Aspnet_mvc_template_cms_sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aspnet_mvc_template_cms_sample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult PageModelLoader(string pname)
        {
            return Json(new PageModel(pname), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult UpdateField(string id, string val, string pname)
        {
            if (Session["login"] == null)
                return Json(new MyJsonResult<string>(true, "Unauthorize access."));

            KmbContext db = new KmbContext();
            PageField field = db.PageFields.FirstOrDefault(x => x.Id == id);

            if (field == null)
            {
                field = new PageField();
                field.Id = id;
                field.PageName = pname;
                db.PageFields.Add(field);
            }

            field.LastModifiedDate = DateTime.Now;
            field.LastModifiedUser = (Session["login"] as KmbUser).Username;
            field.Text = val;

            if (db.SaveChanges() > 0)
                return Json(new MyJsonResult<string>(false, "Update successful."));
            else
                return Json(new MyJsonResult<string>(false, "Update fail."));
        }
    }
}