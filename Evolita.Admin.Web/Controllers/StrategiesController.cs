using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evolita.Admin.Services;
using Evolita.Admin.Tokens;
using Evolita.Admin.Web.Models;

namespace Evolita.Admin.Web.Controllers
{
    public class StrategiesController : Controller
    {
        private IStrategyService _strategyService;

        public StrategiesController(IStrategyService strategyService)
        {
            _strategyService = strategyService;
        }

        // GET: Strategies
        public ActionResult Index()
        {
            return View(_strategyService.GetStrategies());
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
            if (ModelState.IsValid) 
            {
                try
                {
                    StrategyToken token = _strategyService.Create(new StrategyToken { name = model.Name, owner = "<Authenticated User>" });
                    return RedirectToAction("Edit", new { id = token.id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex);
                }
            }
            return View(model);
        }

        // GET: Edit/id
        public ActionResult Edit(string id)
        {
            return View(_strategyService.GetStrategy(id));
        }

        // POST: Question
        [HttpPost]
        public JsonResult Question(string strategyid, string text) 
        {
            try
            {
                _strategyService.AddQuestion(strategyid, text);
                return Json(new { text = text });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        // POST: Research
        [HttpPost]
        public JsonResult Research(string strategyid, string text)
        {
            try
            {
                string id = _strategyService.AddResearch(strategyid, text);
                return Json(new { id = id, text = text });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        // POST: Action
        [HttpPost]
        public JsonResult Action(string strategyid, string researchid, string type, string text)
        {
            try
            {
                string id = _strategyService.AddAction(strategyid, researchid, type, text);
                return Json(new { id = id, type = type,  text = text, researchid = researchid });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
    }
}