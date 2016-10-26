using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspnet_mvc_template_cms_sample.Models
{
    public class PageModelBase : MyJsonResult<string>
    {
        public bool EditMode
        {
            get
            {
                if (HttpContext.Current.Session["login"] != null &&
                    HttpContext.Current.Session["login"] as KmbUser != null)
                    return true;
                else
                    return false;
            }
        }
    }
}