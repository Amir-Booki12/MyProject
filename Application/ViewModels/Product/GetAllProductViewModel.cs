using Common;
using Common.Enums;
using Domain.Entities.ProductAgg;
using System;


namespace Application.ViewModels.Product
{
    public class GetAllProductViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }
        public string StatusTitle =>Status.GetEnumDescription();
        public SeoData SeoData { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationDateShamsy => CreationDate.ConvertMiladiToJalali();
    }
    public class GetAllProductCategoryViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public StatusEnum Status { get; set; }
        public string StatusTitle => Status.GetEnumDescription();
        public SeoData SeoData { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationDateShamsy => CreationDate.ConvertMiladiToJalali();
    }
}
