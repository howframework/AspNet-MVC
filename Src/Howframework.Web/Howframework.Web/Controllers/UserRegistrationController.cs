using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using Howframework.Domain.UserManagement;
using Howframework.Domain.Infrastructure;

namespace Howframework.Web.Controllers
{
    public class UserRegistrationController : Controller
    {
        //
        // GET: /UserRegistration/
        protected IUnitOfWork server;

        public UserRegistrationController()
        {
           
            server = new MongoDbSession();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string fullname,string username,string email,string password)
        {
           
            using (var uow = server.StartUnitOfWork())
            {
                uow.Save<User>(new User { Email = email, FullName = fullname, Password = password, UserName = username });
            }

            return View();
        }
    }
}
