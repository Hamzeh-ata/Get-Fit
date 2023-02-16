using get_fit.Areas.Identity.Pages.Account;
using static get_fit.Areas.Identity.Pages.Account.RegisterModel;

namespace get_fit.Models
{
    public class mainModel
    {
        public changePasswordModel changePassword { get; set; }
        public RegisterModel registerModel { get; set; }
        public InputModel input { get; set; }
        public changeEmailModel changeEmailModel { get; set; }
        public userNameChangeModel userNameChangeModel { get; set; }    
        public changeBirthday changeBirthday { get; set; }
        public  Trainee_information Traineeinformation { get; set; }
        public changeHeight changeHeight { get; set; }
        public changeWeight changeWeight { get; set; }
        public editWorkoutPreferncesModel editPrefernces { get; set; }

    }
}
