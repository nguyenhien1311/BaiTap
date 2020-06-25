using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap.Models.DataModels
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}