using Application.ViewModels.Public;
using System.Collections.Generic;

namespace Application.ViewModels.Product
{
    public class ResponseGetAllProductViewModel: ResponseGetListViewModel
    {
        public List<GetProductViewModel> Items { get; set; }
    }

    public class ResponseGetAllProductCategoryViewModel : ResponseGetListViewModel
    {
        public List<GetProductCategoryViewModel> Items { get; set; }
    }

    public class GetProductViewModel:GetAllProductViewModel
    {

    }
    public class GetProductCategoryViewModel: GetAllProductCategoryViewModel
    {

    }
}
