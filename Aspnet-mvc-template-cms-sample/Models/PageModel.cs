using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspnet_mvc_template_cms_sample.Models
{
    public class PageModel : PageModelBase
    {
        public string PageName { get; set; }
        public List<PageField> PageFields { get; set; }


        public PageModel(string pname)
        {
            this.PageName = pname;
            this.LoadPageFields();
        }

        public void LoadPageFields()
        {
            KmbContext db = new KmbContext();
            this.PageFields = db.PageFields.Where(x => x.PageName == this.PageName).ToList();
        }

        public PageModel()
        {
            this.PageFields = new List<PageField>();
        }
    }
}