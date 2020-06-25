using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaiTap.Models.DataModels
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [AllowHtml]
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}