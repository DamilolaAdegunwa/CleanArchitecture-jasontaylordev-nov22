﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayApp.Application.Common.Models;
public class Constants
{
    public class Sections
    {
        public const string AuthJwtBearer = "Authentication:JwtBearer";
    }
    public static class Url
    {
        public const string WelcomeEmail = "wwwroot/messaging/emailtemplates/welcome-email.html";
        public const string ResetPasswordOTP = "wwwroot/messaging/emailtemplates/reset-password-email.html";
        public const string ResetPasswordSubject = "Array App: Reset Your Password!";
    }
}