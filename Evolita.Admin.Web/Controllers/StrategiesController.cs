using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evolita.Admin.Web.Models;

namespace Evolita.Admin.Web.Controllers
{
    public class StrategiesController : Controller
    {
        // GET: Strategies
        public ActionResult Index()
        {
            return View(new object[0]);
        }

        // GET: Create
        public ActionResult Create() 
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public ActionResult Create(CreateStrategyModel model)
        {
            return View();
        }
    }
}