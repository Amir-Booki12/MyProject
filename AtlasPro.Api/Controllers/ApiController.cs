using Application.BusinessLogic;
using Application.BusinessLogic.Message;
using Common.ResultApi;
using LivestockInput.Api.Helper.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace AtlasPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult ApiResult<TResult>(IBusinessLogicResult<TResult> source)
        {
            var result = new WebApiResult<TResult>();
            result.Result = source.Result;
            result.Exception = source.Exception.GetExceptionMessage();
            result.HttpStatusCode = source.Succeeded ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            result.MessageCode = source.Messages.FirstOrDefault(x => x.Type == MessageType.Error)?.MessageCode ?? 0;
            result.Message = source.Messages.Select(x => x.ViewMessage).ToList();
            if (source.ErrorFileds != null)
                result.ErrorFileds = source.ErrorFileds.ToList();
            else result.ErrorFileds = new List<string>();

            switch (result.HttpStatusCode)
            {
                case HttpStatusCode.OK:
                    return new OkObjectResult(result);
                case HttpStatusCode.BadRequest:
                default:
                    return new BadRequestObjectResult(result);
            }
        }
    }
}