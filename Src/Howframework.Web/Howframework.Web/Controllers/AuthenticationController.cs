using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Howframework.Domain.Infrastructure;
using System.Web.Security;
using MongoDB.Driver.Linq;
using Howframework.Domain.UserManagement;

namespace Howframework.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/

        protected IUnitOfWork server;

        public AuthenticationController()
        {
            server = new MongoDbSession();
        }

        public ActionResult Login()
        {
            if (TempData["Username"] != null)
                ViewBag.Username = TempData["Username"];

            return View();
        }

        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            using (var s = server.StartUnitOfWork())
            {
                var query = s.Query<User>().Where(c => c.UserName == username && c.Password == password).FirstOrDefault();
                if (query != null)
                {
                    FormsAuthentication.SetAuthCookie(username, true);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["ErrorMessage"] = "Invalid username or password";

                    return RedirectToAction("Error", "Notification");
                }
            }
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
