
using Adopt1Dev.ASP.Models;
using Adopt1Dev.ASP.Models.Form;
using Adopt1Dev.ASP.Services;
using Adopt1Dev.ASP.Tools;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Adopt1Dev.ASP.Controllers
{
    public class UserController : Controller
    {

        private readonly IService<UserModel, UserForm> _service;

        public UserController(IService<UserModel, UserForm> service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            IEnumerable<UserModel> model = _service.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserForm form)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.Set<int>("UserId", 26);
                _service.Insert(form);
                TempData["succes"] = "Insertion effectuée";
                //HttpContext.Session.Set<bool>("IsLogged", true);
              
                
                return RedirectToAction("Index", "Home", new { area = "Member" });
            }
            else
            {
                TempData["error"] = "Formulaire invalide";
                return View(form);
            }
        }

        public IActionResult Delete([FromRoute] int id)
        {
            // id récupéré au push button
            if (_service.Delete(id))
            {
                TempData["success"] = "Suppression OK";
            }
            else
            {
                TempData["error"] = "Erreur de suppression";
            }
            //pas de vue, on redirige direct
            return RedirectToAction("Index");
        }
    }
}
