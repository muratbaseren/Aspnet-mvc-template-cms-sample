using Aspnet_mvc_template_cms_sample.Infrastructure.Abstract;
using Aspnet_mvc_template_cms_sample.ModalLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspnet_mvc_template_cms_sample.PageFieldPlugin.Abstract
{
    public abstract class PageModelBase : MyJsonResult<string>
    {
        public bool EditMode
        {
            get
            {
                if (HttpContext.Current.Session["login"] != null &&
                    HttpContext.Current.Session["login"] as LoginUser != null)
                    return true;
                else
                    return false;
            }
        }
    }
}