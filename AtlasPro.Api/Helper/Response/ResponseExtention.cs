﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using LivestockInput.Api.Helper.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Presentation.WebApi
{
    public static class ResponseExtention
    {
        //public static HttpResponseMessage ToHttpResponse(this object data, HttpStatusCode status = HttpStatusCode.OK, double? version = null, Dictionary<string, string> headers = null)
        //{
        //    dynamic objectData = new { value = data };
        //    if (version != null)
        //    {
        //        objectData = new { value = data, version = version };
        //    }
        //    //string token = string.IsNullOrWhiteSpace(paramToken) ? string.Empty : paramToken;
        //    var outData = JsonConvert.SerializeObject(new
        //    {
        //        data = objectData,
        //        //token
        //    }, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

        //    var response = new HttpResponseMessage(status)
        //    {
        //        Content = new StringContent(outData, System.Text.Encoding.UTF8, "application/json")
        //    };
        //    response.StatusCode = status;
        //    if (headers != null)
        //    {
        //        foreach (var item in headers)
        //        {
        //            response.Headers.Add(item.Key, item.Value);
        //        }
        //    }
        //    return response;
        //}

        public static IActionResult ToHttpResponse(this WebApiResult data)
        {
           
            switch (data.HttpStatusCode)
            {
                case HttpStatusCode.OK:
                    return new OkObjectResult(data);
                case HttpStatusCode.BadRequest:
                default:
                    return new BadRequestObjectResult(data);
            }
        }
    }
}
