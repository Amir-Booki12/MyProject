using Common.Enums;
using Domain.Attributes;
using Domain.Entities.BaseAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ProductAgg
{

    [EntityType]
    public class ProductCategory : EntityBaseKey<long>
    {
        public string Title { get; set; }
        public SeoData SeoData { get; set; }
        public long ProdictId { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime CreationDate { get; set; }

        protected ProductCategory()
        {
            
        }
        public ProductCategory(string title, SeoData seoData)
        {
            Title = title;
            SeoData = seoData;
            CreationDate = DateTime.Now;
        }

        public void Edit(string title, SeoData seoData)
        {
            Title = title;
            SeoData = seoData;
            Status = StatusEnum.Active;
        }

        public void ChengeStatus(StatusEnum status)
        {
            Status = status;
        }

        #region Rel
        public List<Product> Products { get; set; }
        #endregion
    }
}

