using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using Howframework.Domain.UserManagement;
using Howframework.Domain.Infrastructure;
using Howframework.Domain.Commands;

namespace Howframework.Web.Controllers
{
    public class UserRegistrationController : Controller
    {
        //
        // GET: /UserRegistration/
        //protected IUnitOfWork server;

        protected IBus bus;

        public UserRegistrationController(IBus bus)
        {
            this.bus = bus;
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
        public ActionResult Register(RegisterUserCommand cmd)
        {
            bus.Send(cmd);

            TempData["Username"] = cmd.username;

            return RedirectToAction("Login", "Authentication");
        }
    }
}
