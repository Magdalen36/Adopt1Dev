using Adopt1Dev.ASP.Models;
using Adopt1Dev.ASP.Models.Form;
using Adopt1Dev.ASP.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adopt1Dev.ASP.Controllers
{
    public class SkillController : Controller
    {
        private readonly IService<SkillModel, SkillForm> _service;

        public SkillController(IService<SkillModel, SkillForm> service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            IEnumerable<SkillModel> model = _service.GetAll();
            return View(model);
        }

        //affichage du formulaire de création
        public IActionResult Create()
        {
            return View();
        }

        //méthode de retour de traitement
        [HttpPost]
        public IActionResult Create(SkillForm form)
        {
            //correct ?

            if (ModelState.IsValid)
            { //Si oui : Appel au service + notification + redirection
                _service.Insert(form);
                TempData["success"] = "Insertion effectuée";
                return RedirectToAction("Index");
            }
            else
            { //Si non : Réafficher la vue avec le form et les erreurs
                return View(form);
            }
        }

        //affichage
        public IActionResult Update([FromRoute] int id) //fromroute non obligatoire
        {
            SkillForm form = _service.GetById(id);

            //retour d'une erreur 404 si le form n'existe pas 
            if (form == null) return NotFound();

            return View(form);
        }

        //traitement
        [HttpPost]
        public IActionResult Update(SkillForm form)
        {
            if (ModelState.IsValid)
            {
                _service.Update(form);
                TempData["success"] = "Modification effectuée";
                return RedirectToAction("Index");
            }
            else
            {
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
