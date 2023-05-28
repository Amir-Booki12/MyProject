using System.Threading.Tasks;
using Application.BusinessLogic;

namespace Application.Services.InterfaceClass.Message
{
    public interface IMessageService
    {
        Task<IBusinessLogicResult<bool>> ChangeAccountStatusMessage(string receiver, string message);
    }
}