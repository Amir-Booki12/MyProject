using System.Collections.Generic;
using System.Threading.Tasks;
using Application.BusinessLogic;

namespace Application.Services.InterfaceClass.Location
{
    public interface ILocationService
    {
        Task<IBusinessLogicResult<List<KeyValuePair<int,string>>>> GetAllMainLocationForDropDown();
        Task<IBusinessLogicResult<List<KeyValuePair<int, string>>>> GetAllProvincesForDropDown();
        Task<IBusinessLogicResult<List<KeyValuePair<int, string>>>> GetAllCountiesForDropDown(int provinceId);
        Task<IBusinessLogicResult<List<KeyValuePair<int, string>>>> GetAllCityOrVillagesForDropDown(int countyId);
    }
}