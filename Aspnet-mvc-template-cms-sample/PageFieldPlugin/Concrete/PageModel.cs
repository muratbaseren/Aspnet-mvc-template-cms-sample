using Aspnet_mvc_template_cms_sample.Context;
using Aspnet_mvc_template_cms_sample.PageFieldPlugin.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Aspnet_mvc_template_cms_sample.PageFieldPlugin.Concrete
{
    public class PageModel : PageModelBase
    {
        public string PageName { get; set; }
        public List<BasicPageField> PageFields { get; set; }


        public PageModel(string pname)
        {
            this.PageName = pname;
            this.LoadPageFields();
        }

        public void LoadPageFields()
        {
            SampleDatabaseContext db = new SampleDatabaseContext();
            this.PageFields = db.BasicPageFields.Where(x => x.PageName == this.PageName).ToList();
        }

        public PageModel()
        {
            this.PageFields = new List<BasicPageField>();
        }
    }
}