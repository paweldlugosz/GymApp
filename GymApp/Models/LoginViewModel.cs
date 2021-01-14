using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Models
{
    public class LoginViewModel
    {
        public string ErrorText { get; set; }

        public LoginViewModel(string errorText)
        {
            ErrorText = errorText;
        }
    }
}
