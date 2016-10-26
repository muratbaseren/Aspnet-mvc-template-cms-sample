using System.ComponentModel.DataAnnotations;

namespace Aspnet_mvc_template_cms_sample.Models
{
    public abstract class PageFieldBase
    {
        [Key, Required, StringLength(100)]
        public string Id { get; set; }

        [Required, StringLength(120)]
        public string PageName { get; set; }
    }
}