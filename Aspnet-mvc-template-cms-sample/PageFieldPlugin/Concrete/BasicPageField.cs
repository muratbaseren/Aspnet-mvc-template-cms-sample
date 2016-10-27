using Aspnet_mvc_template_cms_sample.PageFieldPlugin.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aspnet_mvc_template_cms_sample.PageFieldPlugin.Concrete
{
    [Table("PageField")]
    public class BasicPageField : PageFieldBase
    {
        public string Text { get; set; }

        [Required]
        public DateTime LastModifiedDate { get; set; }

        [Required, StringLength(30)]
        public string LastModifiedUser { get; set; }
    }
}