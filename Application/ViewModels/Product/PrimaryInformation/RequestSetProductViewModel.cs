

using Common.Enums;
using Domain.Entities.ProductAgg;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.Product.PrimaryInformation
{
    public class RequestSetProductViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [Range(1,10000)]
        public int Price { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public SeoData SeoData { get; set; }
    }
}
