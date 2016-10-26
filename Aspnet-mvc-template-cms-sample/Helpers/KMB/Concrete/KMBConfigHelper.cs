using System.Configuration;

namespace Aspnet_mvc_template_cms_sample.Helpers.KMB.Concrete
{
    public class KMBConfigHelper
    {
        public static string MailHost = ConfigurationManager.AppSettings["KMBMailHost"];
        public static string MailPort = ConfigurationManager.AppSettings["KMBMailPort"];
        public static string MailUid = ConfigurationManager.AppSettings["KMBMailUid"];
        public static string MailPass = ConfigurationManager.AppSettings["KMBMailPass"];
    }
}
