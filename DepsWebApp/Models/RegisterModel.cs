﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepsWebApp.Models
{
    /// <summary>
    /// Save when user was registered
    /// </summary>
    public class RegisterModel
    {
#pragma warning disable 1591
        public RegisterModel(string login, string password)

        {
            Login = login;
            Password = password;
        }

        public RegisterModel()
        {
        }
#pragma warning restore 1591
        /// <summary>
        /// User have login
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Use have password
        /// </summary>
        public string Password { get; set; }
    }
}
