using Common.Enums;

namespace Application.ViewModels.User.PrimaryInformation
{
    public class ChangeUserPrimaryInformationStatusViewModel
    {
        public string UserName { get; set; }
        public StatusEnum StatusEnum { get; set; }
    }
}