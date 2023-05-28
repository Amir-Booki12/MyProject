using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ProductAgg
{
    public class SeoData
    {
        public string Slug { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string Canonical { get;  set; }
    }
}
