using Aspnet_mvc_template_cms_sample.Context;
using Aspnet_mvc_template_cms_sample.Infrastructure.Abstract;
using Aspnet_mvc_template_cms_sample.ModalLogin.Models;
using Aspnet_mvc_template_cms_sample.PageFieldPlugin.Concrete;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Aspnet_mvc_template_cms_sample.Controllers
{
    public class PageFieldController : Controller
    {

        public ActionResult SamplePage()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetPageFields(string pname)
        {
            PageModel model = new PageModel(pname);
            model.LoadPageFields();

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult UpdatePageField(string id, string val, string pname)
        {
            if (Session["login"] == null)
                return Json(new MyJsonResult<string>(true, "Unauthorize access."));

            SampleDatabaseContext db = new SampleDatabaseContext();
            BasicPageField field = db.BasicPageFields.FirstOrDefault(x => x.Id == id);

            if (field == null)
            {
                field = new BasicPageField();
                field.Id = id;
                field.PageName = pname;
                db.BasicPageFields.Add(field);
            }

            field.LastModifiedDate = DateTime.Now;
            field.LastModifiedUser = (Session["login"] as LoginUser).Username;
            field.Text = val;

            if (db.SaveChanges() > 0)
                return Json(new MyJsonResult<string>(false, "Update successful."));
            else
                return Json(new MyJsonResult<string>(false, "Update fail."));
        }
    }
}