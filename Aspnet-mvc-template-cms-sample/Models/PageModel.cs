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

            KmbContext db = new KmbContext();
            this.PageFields = db.PageFields.Where(x => x.PageName == pname).ToList();
        }

        public PageModel()
        {
            this.PageFields = new List<PageField>();
        }
    }
}