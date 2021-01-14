using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Models
{
    public class SignupViewModel
    {
        public bool Success { get; set; }

        public string ErrorText { get; set; }

        public string UserName { get; set; }

        public SignupViewModel(bool success, string errorText, string userName)
        {
            Success = success;
            ErrorText = errorText;
            UserName = userName;
        }

        public static SignupViewModel newErrorInstance(string errorText)
        {
            return new SignupViewModel(false, errorText, null);
        }

        public static SignupViewModel newSuccessInstance(string userName)
        {
            return new SignupViewModel(true, null, userName);
        }
    }
}
