using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aspnet_mvc_template_cms_sample.Models
{
    [Table("PageField")]
    public class PageField : KmbCmsPage
    {
        public string Text { get; set; }

        [Required]
        public DateTime LastModifiedDate { get; set; }

        [Required, StringLength(30)]
        public string LastModifiedUser { get; set; }
    }
}