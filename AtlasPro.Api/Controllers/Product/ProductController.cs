using Application.Services.InterfaceClass.Products;
using Application.Services.InterfaceClass.User;
using Application.ViewModels.Product;
using Application.ViewModels.Product.PrimaryInformation;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace SOP.Api.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiController
    {

        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        //private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        public ProductController(IProductService ProductService,
            ILogger<ProductController> logger)
        {
            _productService = ProductService;
            _logger = logger;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetProduct(long id)
        {
            _logger.LogInformation("GetProduct");
            return ApiResult( await _productService.GetProduct(id));
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductByFilter([FromBody] RequestGetAllProductViewModel model)
        {
            _logger.LogInformation("GetProductByFilter");
            return ApiResult(await _productService.GetProductByFilter( model));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductCategoryByFilter([FromBody]RequestGetAllProductCategoryViewModel model)
        {
            _logger.LogInformation("GetProductCategoryByFilter");
            return ApiResult(await _productService.GetProductCategoryByFilter(model));
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> SetProduct([FromBody] RequestSetProductViewModel model)
        {
            _logger.LogInformation("SetProduct");
            return ApiResult(await _productService.SetProduct(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SetProductCategory([FromBody] RequestSetProductCategoryViewModel model)
        {
            _logger.LogInformation("SetProductCategory");
            return ApiResult(await _productService.SetProductCategory(model));
        }

        [HttpPut]
        public async Task<IActionResult> EditProduct([FromBody] EditProductViewModel model)
        {
            _logger.LogInformation("EditProduct");
            return ApiResult(await _productService.EditProduct(model));
        }
        [HttpPut]
        public async Task<IActionResult> EditProductCategory([FromBody] EditProductCategoryViewModel model)
        {
            _logger.LogInformation("EditProductCategory");
            return ApiResult(await _productService.EditProductCategory(model));
        }
    }
}
