using Asp_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp_mvc.Tools
{
    public class SessionManager
    {
        public static User user
        {
            get { return (User)HttpContext.Current.Session["user"]; }
            set { HttpContext.Current.Session["user"]=value; }
        }
        public static string UserName
        {
            get { return (string)HttpContext.Current.Session["UserName"]; }
            set { HttpContext.Current.Session["UserName"] = value; }
        }
    }
}