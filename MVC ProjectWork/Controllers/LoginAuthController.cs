using MVC_ProjectWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_ProjectWork.Controllers
{
   
    public class LoginAuthController : Controller
    {
        MVC_ProjectEntities1 db = new MVC_ProjectEntities1();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(user u, string ReturnUrl)
        {
            if(IsValid(u) == true)
            {
                FormsAuthentication.SetAuthCookie(u.username, false);
                Session["username"] = u.username.ToString();
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "HomeAuth");
                }
            }
            else
            {
                return View();
            }
            
        }


        public bool IsValid(user u)
        {
            var credentials = db.users.Where(model => model.username == u.username && model.password == u.password).FirstOrDefault();
           if(credentials != null)
            {
                return (u.username == credentials.username && u.password == credentials.password);
            }
            else
            {
                return false;
            }
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["username"] = null;
            return RedirectToAction("Index", "HomeAuth");

            
        }
    }
}