using Application.BusinessLogic.Message;
using Application.BusinessLogic;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Response
{
    public class ResponseService<Tservice> where Tservice : class
    {
        private readonly ILogger<Tservice> _logger;
        public ResponseService(ILogger<Tservice> logger)
        {
            _logger = logger;
        }
        public async Task<IBusinessLogicResult<TResponse>> ErrorServiceResultAsync<TResponse>(TResponse response, MessageId message, string loggerMessage, params string[] viewMessagesPlaceHolder) 
        {
            var messages = new List<BusinessLogicMessage>();
            _logger.LogError(loggerMessage);
            messages.Add(new BusinessLogicMessage(type: MessageType.Error, message: message, viewMessagesPlaceHolder));
            return new BusinessLogicResult<TResponse>(succeeded: false, result: response, messages: messages);
        }

        public async Task<IBusinessLogicResult<TResponse>> ExceptionServiceResultAsync<TResponse>(TResponse response, string loggerMessage, params string[] viewMessagesPlaceHolder)
        {
             var messages = new List<BusinessLogicMessage>();
            _logger.LogError(loggerMessage);
            messages.Add(new BusinessLogicMessage(type: MessageType.Error, message: MessageId.Exception, viewMessagesPlaceHolder));
            return new BusinessLogicResult<TResponse>(succeeded: false, result: response, messages: messages);
        }

        public void Log(string message, bool isError)
        {
            if (isError)
            {
                _logger.LogError(message);
            }
            else
            {
                _logger.LogInformation(message);
            }
        }
        public async Task<IBusinessLogicResult<TResponse>> SuccessServiceResultAsync<TResponse>(TResponse response)
        {
            var messages = new List<BusinessLogicMessage>();
            _logger.LogInformation("Success Process");
            messages.Add(new BusinessLogicMessage(type: MessageType.Info, message: MessageId.Success));
            return new BusinessLogicResult<TResponse>(succeeded: true, result: response, messages: messages);
        }

        //public async Task<IBusinessLogicResult<TResponse>> ErrorServiceResultAsync<TResponse>(TResponse response, MessageId message,ILogger _logger)
        //{
        //    var messages = new List<BusinessLogicMessage>();
        //    _logger.LogError("Error while setting manager to factory.");
        //    messages.Add(new BusinessLogicMessage(type: MessageType.Error, message: message));
        //    return new BusinessLogicResult<TResponse>(succeeded: false, result: response, messages: messages);
        //}

        //public async Task<IBusinessLogicResult<TResponse>> SuccessServiceResultAsync<TResponse>(this TResponse response, MessageId message, ILogger _logger)
        //{
        //    var messages = new List<BusinessLogicMessage>();
        //    _logger.LogError("Error while setting manager to factory.");
        //    messages.Add(new BusinessLogicMessage(type: MessageType.Info, message: MessageId.CannotAddToUser, "نقش مدیر", "انتخاب شده"));
        //    return new BusinessLogicResult<TResponse>(succeeded: true, result: response, messages: messages);
        //}
    }
}
