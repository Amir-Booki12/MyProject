using System.ComponentModel.DataAnnotations;

namespace Application.BusinessLogic.Message
{
    public enum MessageId
    {
        [Display(Name = "عملیات با موفقیت انجام شد.")]
        Success = 1,
        [Display(Name = "مشکلی در سیستم بوجود آمده است.")]
        Exception = -1,
        [Display(Name = "اطلاعات کاربر یافت نشد")]
        NotExistsUser = -2,
        [Display(Name = "نام کاربری {0} قبلا در سیستم وجود داشته است.")]
        UserNameAlreadyExisted = -3,
        [Display(Name = "رکوردی یافت نشد")]
        EntityDoesNotExist = -4,
        [Display(Name = "کاربر به این قسمت دسترسی ندارد")]
        UserCannotAccessToLocation = -5,
        [Display(Name = "برای کاربر اطلاعات کارخانه ثبت نشده است.")]
        UserFactoryNotFound = -6,
        [Display(Name = "نام دامنه تکراری است.")]
        DomainNameIsExists = -7,
        [Display(Name = "شما به عنوان کاربر کارخانه نمی باشید")]
        UserIsNotFactoryUser = -8,
        [Display(Name = "عضو انتخاب شده معتبر نمی باشد")]
        selectedMemberNotValid = -9,
        [Display(Name = "ارسال پیام با موفقیت انجام نشد")]
        SendMessageNotSuccess = -10,
        [Display(Name = "خطا در ثبت اطلاعات")]
        Unsuccessful = -11,
        [Display(Name = "شناسه کارخانه صحیح نمی باشد")]
        FactoryNotExists = -12,
        [Display(Name = "در مرحله ثبت نهایی ، اجازه عملیات ندارید")]
        FinalRegister = -13,
        [Display(Name = "اطلاعات تکراری میباشد")]
        DuplicateInformation = -14,
        [Display(Name = "کاربر قبلا به این اصالت تولید محصول امتیاز داده است")]
        UserHasAlreadyRatedForCurrentManufactureProduct = -15,
    }
}