using System.Configuration;

namespace Aspnet_mvc_template_cms_sample.Infrastructure.Concrete
{
    internal class ConfigHelper
    {
        public static string MailHost = ConfigurationManager.AppSettings["_MailHost"];
        public static string MailPort = ConfigurationManager.AppSettings["_MailPort"];
        public static string MailUid = ConfigurationManager.AppSettings["_MailUid"];
        public static string MailPass = ConfigurationManager.AppSettings["_MailPass"];
    }
}
