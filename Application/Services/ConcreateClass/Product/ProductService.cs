using Application.BusinessLogic;
using Application.BusinessLogic.Message;
using Application.IRepositories;
using Application.Services.ConcreateClass.User;
using Application.Services.InterfaceClass.Products;
using Application.Services.InterfaceClass.User;
using Application.Services.Response;

using Application.ViewModels.Product;
using Application.ViewModels.Product.PrimaryInformation;
using Application.ViewModels.User;
using AutoMapper;
using Common;
using Domain.Entities.LocationsAgg;
using Domain.Entities.ProductAgg;
using Domain.Entities.UserAgg;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ConcreateClass.Product
{
    public class ProductService : ResponseService<ProductService>, IProductService
    {
        private readonly IRepository<Domain.Entities.ProductAgg.Product> _productRepository;
        private readonly IRepository<ProductCategory> _productCategoryRepository;

        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper,
          ILogger<ProductService> logger) : base(logger)
        {
            _productRepository = unitOfWork.GetRepository<Domain.Entities.ProductAgg.Product>();
            _productCategoryRepository = unitOfWork.GetRepository<ProductCategory>();
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IBusinessLogicResult<bool>> SetProduct(RequestSetProductViewModel model)
        {
            try
            {
                if (_productRepository.Any(x => x.Title == model.Title))
                    return await ErrorServiceResultAsync<bool>(false, MessageId.DuplicateInformation, $"قبلا محصولی با این نام ثبت شده است");

                var product = new Domain.Entities.ProductAgg.Product(model.Title, model.Price, model.Description, model.SeoData);
                return await SuccessServiceResultAsync<bool>(true);
            }
            catch (Exception ex)
            {
                return await ExceptionServiceResultAsync<bool>(
                    response: false,
                    "error while getting all user with filter"
                );
            }
        }

        public async Task<IBusinessLogicResult<bool>> SetProductCategory(RequestSetProductCategoryViewModel model)
        {
            try
            {
                if (_productCategoryRepository.Any(x => x.Title == model.Title))
                    return await ErrorServiceResultAsync<bool>(false, MessageId.DuplicateInformation, $"قبلا گروهی با این نام ثبت شده است");

                var product = new ProductCategory(model.Title, model.SeoData);
                return await SuccessServiceResultAsync<bool>(true);
            }
            catch (Exception ex)
            {
                return await ExceptionServiceResultAsync<bool>(
                    response: false,
                    "error while getting all user with filter"
                );
            }
        }

        public async Task<IBusinessLogicResult<bool>> EditProduct(EditProductViewModel model)
        {
            try
            {
                var product = _productRepository.Get(model.Id);
                if (product == null)
                    return await ErrorServiceResultAsync<bool>(false, MessageId.EntityDoesNotExist, $"محصولی یافت نشد!");
                if (_productCategoryRepository.Any(x => x.Title == model.Title&&x.Id!=model.Id))
                    return await ErrorServiceResultAsync<bool>(false, MessageId.DuplicateInformation, $"قبلا محصولی با این نام ثبت شده است");

                product.Edit(model.Title, model.Price, model.Description, model.SeoData);
                await _productRepository.UpdateAsync(product,true);
                return await SuccessServiceResultAsync<bool>(true);
            }
            catch (Exception ex)
            {
                return await ExceptionServiceResultAsync<bool>(
                    response: false,
                    "error while getting all user with filter"
                );
            }
        }

        public async Task<IBusinessLogicResult<bool>> EditProductCategory(EditProductCategoryViewModel model)
        {
            try
            {
                var productCategory = _productCategoryRepository.Get(model.Id);
                if (productCategory == null)
                    return await ErrorServiceResultAsync<bool>(false, MessageId.EntityDoesNotExist, $"گروهی یافت نشد!");
                if (_productCategoryRepository.Any(x => x.Title == model.Title && x.Id != model.Id))
                    return await ErrorServiceResultAsync<bool>(false, MessageId.DuplicateInformation, $"قبلا گروهی با این نام ثبت شده است");

                productCategory.Edit(model.Title, model.SeoData);
                await _productCategoryRepository.UpdateAsync(productCategory, true);
                return await SuccessServiceResultAsync<bool>(true);
            }
            catch (Exception ex)
            {
                return await ExceptionServiceResultAsync<bool>(
                    response: false,
                    "error while getting all user with filter"
                );
            }
        }





        public async Task<IBusinessLogicResult<GetAllProductViewModel>> GetProduct(long ProductId)
        {
            try
            {
                var product = _productRepository.DeferredWhere(x => x.Id == ProductId).Include(x => x.Category);
                if (product == null)
                    return await ErrorServiceResultAsync<GetAllProductViewModel>(null, MessageId.EntityDoesNotExist, $"محصولی یافت نشد!");


                var result = product.Select(x => new GetAllProductViewModel
                {
                    Id = x.Id,
                    Price = x.Price,
                    SeoData = x.SeoData,
                    Description = x.Description,
                    CreationDate = x.CreationDate,
                    Status = x.Status,
                    Title = x.Title,
                    CategoryId = x.Category.Id,
                    CategoryName = x.Category.Title

                }).FirstOrDefault();

                return await SuccessServiceResultAsync<GetAllProductViewModel>(result);
            }

            catch (Exception ex)
            {
                return await ExceptionServiceResultAsync<GetAllProductViewModel>(
                    response: null,
                    "error while getting all user with filter"
                );
            }


        }

        public async Task<IBusinessLogicResult<ResponseGetAllProductViewModel>> GetProductByFilter(RequestGetAllProductViewModel model)
        {
            try
            {
                var product = _productRepository.DeferdSelectAll().Include(x => x.Category).AsQueryable();
                if (product == null)
                    return await ErrorServiceResultAsync<ResponseGetAllProductViewModel>(null, MessageId.EntityDoesNotExist, $"محصولی یافت نشد!");

                if (!string.IsNullOrWhiteSpace(model.Title))
                    product = product.Where(x => x.Title.Contains(model.Title));

                if (model.Status != null)
                    product = product.Where(x => x.Status == model.Status);

                if (model.CategoryId > 0)
                    product = product.Where(x => x.CategoryId == model.CategoryId);

                var Productitem = product.Select(X => new GetProductViewModel
                {
                    Id = X.Id,
                    Title = X.Title,
                    CategoryId = X.CategoryId,
                    Status = X.Status,
                    CreationDate = X.CreationDate,
                    Price = X.Price,
                    SeoData = X.SeoData,
                    Description = X.Description,
                    CategoryName = X.Category.Title
                }).AsEnumerable().ToPaged(model.Page, model.PageSize, out var rowCount);

                var result = new ResponseGetAllProductViewModel
                {
                    Count = rowCount,
                    CurrentPage = model.Page,
                    TotalCount = product.Count(),
                    Items = Productitem.ToList()
                };

                return await SuccessServiceResultAsync<ResponseGetAllProductViewModel>(result);
            }

            catch (Exception ex)
            {
                return await ExceptionServiceResultAsync<ResponseGetAllProductViewModel>(
                    response: null,
                    "error while getting all user with filter"
                );
            }
        }

        public async Task<IBusinessLogicResult<ResponseGetAllProductCategoryViewModel>> GetProductCategoryByFilter(RequestGetAllProductCategoryViewModel model)
        {
            try
            {
                var productCategory = _productCategoryRepository.DeferdSelectAll().Include(x => x.Products).AsQueryable();
                if (productCategory == null)
                    return await ErrorServiceResultAsync<ResponseGetAllProductCategoryViewModel>(null, MessageId.EntityDoesNotExist, $"محصولی یافت نشد!");

                if (!string.IsNullOrWhiteSpace(model.Title))
                    productCategory = productCategory.Where(x => x.Title.Contains(model.Title));

                if (model.Status != null)
                    productCategory = productCategory.Where(x => x.Status == model.Status);

                if (model.ProductId > 0)
                    productCategory = productCategory.Where(x => x.ProdictId == model.ProductId);

                var ProductCategoryItem = productCategory.Select(X => new GetProductCategoryViewModel
                {
                    Id = X.Id,
                    Title = X.Title,
                    ProductId = X.ProdictId,
                    Status = X.Status,
                    CreationDate = X.CreationDate,
                    SeoData = X.SeoData,


                }).AsEnumerable().ToPaged(model.Page, model.PageSize, out var rowCount);

                var result = new ResponseGetAllProductCategoryViewModel
                {
                    Count = rowCount,
                    CurrentPage = model.Page,
                    TotalCount = productCategory.Count(),
                    Items = ProductCategoryItem.ToList(),


                };

                return await SuccessServiceResultAsync<ResponseGetAllProductCategoryViewModel>(result);
            }

            catch (Exception ex)
            {
                return await ExceptionServiceResultAsync<ResponseGetAllProductCategoryViewModel>(
                    response: null,
                    "error while getting all user with filter"
                );
            }
        }




    }

}

