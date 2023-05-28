using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.BusinessLogic;
using Application.BusinessLogic.Message;
using Application.IRepositories;
using Application.Services.InterfaceClass.Location;
using Application.Services.Response;
using Domain.Entities.LocationsAgg;
using Microsoft.Extensions.Logging;

namespace Application.Services.ConcreateClass.Location
{
    public class LocationService : ResponseService<LocationService>, ILocationService
    {
        private readonly IRepository<MainLocation> _mainLocationRepository;
        private readonly IRepository<Province> _provinceRepository;
        private readonly IRepository<County> _countyRepository;
        private readonly IRepository<CityOrVilage> _cityOrVillageRepository;

        public LocationService(IUnitOfWork unitOfWork, ILogger<LocationService> logger) : base(logger)
        {
            _mainLocationRepository = unitOfWork.GetRepository<MainLocation>();
            _provinceRepository = unitOfWork.GetRepository<Province>();
            _countyRepository = unitOfWork.GetRepository<County>();
            _cityOrVillageRepository = unitOfWork.GetRepository<CityOrVilage>();
        }


        public async Task<IBusinessLogicResult<List<KeyValuePair<int,string>>>> GetAllMainLocationForDropDown()
        {
            try
            {
                var result = _mainLocationRepository.DeferdSelectAll().Select(x => new KeyValuePair<int,string>(x.Id,x.Title)).ToList();
                return await SuccessServiceResultAsync(result);
            }
            catch (Exception e)
            {
                return await ExceptionServiceResultAsync<List<KeyValuePair<int,string>>>(
                    response: null,
                    loggerMessage: "Error while getting provinces"
                );
            }

        }

        public async Task<IBusinessLogicResult<List<KeyValuePair<int,string>>>> GetAllProvincesForDropDown()
        {
            try
            {
                var result = _provinceRepository.DeferdSelectAll().Select(x => new KeyValuePair<int, string>(x.Id, x.Title)).ToList();
                return await SuccessServiceResultAsync(result);
            }
            catch (Exception e)
            {
                return await ExceptionServiceResultAsync<List<KeyValuePair<int,string>>>(
                    response: null,
                    loggerMessage: "Error while getting provinces"
                );
            }
        }

        public async Task<IBusinessLogicResult<List<KeyValuePair<int,string>>>> GetAllCountiesForDropDown(int provinceId)
        {
            try
            {
                var result = _countyRepository.DeferredWhere(x => x.ProvinceId == provinceId).Select(x =>  new KeyValuePair<int, string>(x.Id, x.Title)).ToList();
                return await SuccessServiceResultAsync(result);
            }
            catch (Exception e)
            {
                return await ExceptionServiceResultAsync<List<KeyValuePair<int,string>>>(
                    response: null,
                    loggerMessage: "Error while getting counties"
                );
            }
        }

        public async Task<IBusinessLogicResult<List<KeyValuePair<int,string>>>> GetAllCityOrVillagesForDropDown(int countyId)
        {
            try
            {
                var result = _cityOrVillageRepository.DeferredWhere(x => x.Part.CountyId == countyId).Select(x => new KeyValuePair<int, string>(x.Id, x.Title)).ToList();
                return await SuccessServiceResultAsync(result);
            }
            catch (Exception e)
            {
                return await ExceptionServiceResultAsync<List<KeyValuePair<int,string>>>(
                    response: null,
                    loggerMessage: "Error while getting city or villages"
                );
            }
        }

    }
}