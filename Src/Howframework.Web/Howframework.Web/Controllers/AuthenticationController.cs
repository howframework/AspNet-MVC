using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Howframework.Domain.Infrastructure;
using System.Web.Security;

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
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            using (var s = server.StartUnitOfWork())
            {
                FormsAuthentication.SetAuthCookie(username, true);
                return RedirectToAction("Index", "Dashboard");
            }
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
