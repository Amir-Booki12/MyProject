using Domain.Entities.ProductAgg;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.Product.PrimaryInformation
{
    public class RequestSetProductCategoryViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public SeoData SeoData { get; set; }
    }
}
