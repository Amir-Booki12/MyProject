using Application.ViewModels.Public;
using Common.Enums;


namespace Application.ViewModels.Product
{
    public class RequestGetAllProductViewModel: RequestGetListViewModel
    {
        public string? Title { get; set; }
        public long CategoryId { get; set; }
        public StatusEnum? Status { get; set; }
    }


    public class RequestGetAllProductCategoryViewModel : RequestGetListViewModel
    {
        public string? Title { get; set; }
        public long ProductId { get; set; }   
        public StatusEnum? Status { get; set; }
    }
}
