using System;
using System.Threading.Tasks;
using Application.BusinessLogic;
using Application.BusinessLogic.Message;
using Application.Services.InterfaceClass.Message;
using Application.Services.Response;
using Common.Enum;
using Common.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace Application.Services.ConcreateClass.Messages
{
    public class SmsMessageService : ResponseService<SmsMessageService>, IMessageService
    {
        private readonly IConfiguration _configuration;

        public SmsMessageService(IConfiguration configuration, ILogger<SmsMessageService> logger) : base(logger)
        {
            _configuration = configuration;
        }

        public async Task<IBusinessLogicResult<bool>> ChangeAccountStatusMessage(string receiver, string message)
        {
            try
            {
                var sendMessageResult = SendSmsByPattern(SmsPatternEnum.ChangeUserTypeStatus, receiver,
                    SmsMessagesEnum.Simple, message);
                if (sendMessageResult)
                {
                    return await SuccessServiceResultAsync(true);
                }

                return await ErrorServiceResultAsync(
                    response: false,
                    message: MessageId.SendMessageNotSuccess,
                    loggerMessage: $"send sms message with code {message} to receiver with mobile number {receiver} not successfully"
                );

            }
            catch (Exception exception)
            {
                return await ErrorServiceResultAsync(
                    response: false,
                    message: MessageId.Exception,
                    loggerMessage: $"error while sending sms message for change user status | {exception.Message}"
                );
            }
        }

        private bool SendSmsByPattern(SmsPatternEnum smsPattern, string receiver, SmsMessagesEnum message, string token)
        {
            var apiKey = _configuration.GetSection("Sms:ApiKey").Value;
            var url = _configuration.GetSection("Sms:ByPatternUrl").Value;
            var urlWithKey = string.Format(url, apiKey);

            var restClientOptions = new RestClientOptions(urlWithKey)
            {
                Timeout = -1,
                ThrowOnAnyError = true
            };
            var client = new RestClient(restClientOptions);

            var request = new RestRequest("lookup.json")
                .AddParameter("receptor", receiver)
                .AddParameter("token", token)
                .AddParameter("template", smsPattern.GetPatternName());

            var response = client.PostAsync(request).Result;
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}