using Infrastructure.Security;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Services.InterfaceClass.Location;

namespace AtlasPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ApiController
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }


        /// <summary>
        /// لیست همه ی کشوره ها برای دراپ داون
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [PermissionChecker]
        public async Task<IActionResult> GetAllMainLocationForDropDown()
        {
            return ApiResult(await _locationService.GetAllMainLocationForDropDown());
        }

        /// <summary>
        /// لیست همه ی استان ها برای دراپ داون
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [PermissionChecker]
        public async Task<IActionResult> GetAllProvincesForDropDown()
        {
            return ApiResult(await _locationService.GetAllProvincesForDropDown());
        }
        
        /// <summary>
        /// لیست همه ی شهرستان ها ی استان برای دراپ داون
        /// </summary>
        /// <param name="provinceId"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        [PermissionChecker]
        public async Task<IActionResult> GetAllCountiesForDropDown(int provinceId)
        {
            return ApiResult(await _locationService.GetAllCountiesForDropDown(provinceId));
        }
        
        /// <summary>
        /// * لیست همه ی شهر/روستا های شهرستان
        /// </summary>
        /// <param name="countyId"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        [PermissionChecker]
        public async Task<IActionResult> GetAllCityOrVillagesForDropDown(int countyId)
        {
            return ApiResult(await _locationService.GetAllCityOrVillagesForDropDown(countyId));
        }
    }
}
