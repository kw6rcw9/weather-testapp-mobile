using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTestApp.Data.Models
{
    [Serializable]
    public class AuthUser
    {
        public string Login { get; set; }
        public string Email { get; set; }

        public AuthUser(string login, string email)
        {
            Login = login;
            Email = email;
        }
        public AuthUser() { }
    }
}
