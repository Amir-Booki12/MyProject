

using Application.BusinessLogic;
using Application.ViewModels.Product;
using Application.ViewModels.Product.PrimaryInformation;
using System.Threading.Tasks;

namespace Application.Services.InterfaceClass.Products
{
    public interface IProductService
    {
        public Task<IBusinessLogicResult<bool>> SetProduct(RequestSetProductViewModel model);
        public Task<IBusinessLogicResult<bool>> EditProduct(EditProductViewModel model);
        public Task<IBusinessLogicResult<bool>> SetProductCategory(RequestSetProductCategoryViewModel model);
        public Task<IBusinessLogicResult<bool>> EditProductCategory(EditProductCategoryViewModel model);



        public Task<IBusinessLogicResult<GetAllProductViewModel>> GetProduct(long ProductId);
        public Task<IBusinessLogicResult<ResponseGetAllProductViewModel>> GetProductByFilter(RequestGetAllProductViewModel model);
        public Task<IBusinessLogicResult<ResponseGetAllProductCategoryViewModel>> GetProductCategoryByFilter(RequestGetAllProductCategoryViewModel model);
    
    }
}
