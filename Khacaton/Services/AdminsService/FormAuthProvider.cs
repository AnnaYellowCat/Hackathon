using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Khacaton.Services.AdminsService
{
    public class FormAuthProvider : IAuthProvider
    {
        public bool Authenticate(string user, string password)
        {
            bool result = FormsAuthentication.Authenticate(user, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(user, false);
            }
            return result;
        }
    }
}