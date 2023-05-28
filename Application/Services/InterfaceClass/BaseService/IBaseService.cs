using Application.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.InterfaceClass.BaseService
{
    public interface IBaseService<TResponse, TRequest>
    {
        public Task<IBusinessLogicResult<TResponse>> Set(TRequest request);
        public Task<IBusinessLogicResult<TResponse>> FindById(int id);
    }
}
