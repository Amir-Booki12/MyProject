using Common.Enums;
using Domain.Attributes;
using Domain.Entities.BaseAgg;
using System;

namespace Domain.Entities.ProductAgg
{
    [EntityType]
    public class Product : EntityBaseKey<long>
    {
       
        public string Title { get; set; }
        public int Price { get; set; }
        public long CategoryId { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }
        public SeoData? SeoData { get; set; }
        public DateTime CreationDate { get; set; }


        public Product()
        {
        }
        public Product(string title, int price, string description, SeoData seoData)
        {
            Title = title;
            Price = price;
            Description = description;
            SeoData = seoData;
            Status = StatusEnum.Active;
            CreationDate = DateTime.Now;
        }

        public void Edit(string title, int price, string description, SeoData seoData)
        {
            Title = title;
            Price = price;
            Description = description;
            SeoData = seoData;
        }
        public void ChengeStatus(StatusEnum status)
        {
            Status = status;
        }

        #region Rel
        public ProductCategory Category { get; set; }
        #endregion
    }
}

