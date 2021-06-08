
using Adopt1Dev.ASP.Models;
using Adopt1Dev.ASP.Models.Form;
using Adopt1Dev.ASP.Services;
using Adopt1Dev.ASP.Tools;
using Adopt1Dev.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Adopt1Dev.ASP.Areas.Member.Controllers
{
    [Area("Member")]
    public class HomeController : Controller
    {
        private readonly IService<UserModel, UserForm> _userService;
        private readonly IService<SkillModel, SkillForm> _skillService;
        private readonly IService<NotationModel, NotationForm> _notationService;

        public HomeController(IService<UserModel, UserForm> userService, IService<SkillModel, SkillForm> skillService, IService<NotationModel, NotationForm> notationService)
        {
            _userService = userService;
            _skillService = skillService;
            _notationService = notationService;
        }

        public IActionResult Index()
        {
            //MembreUserModel um = SessionUtils.ConnectedUser;
            TempData["success"] = "Bienvenue";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult AddPicture()
        {
            UserForm form = _userService.GetById(HttpContext.Session.Get<int>("UserId"));
            if (form == null) return NotFound();
            else return View();
        }

        [HttpPost]
        public IActionResult AddPicture(IFormFile ImageFile)
        {

            //form.UserService = _userService;

            if (ModelState.IsValid)
            {
                string[] TypeAutorise = { "image/jpeg", "image/jpg", "image/png", "image/gif" };
                byte[] imageEnByte = null;

                //Check notre fichier
                //Est ce qu'on a un fichier ?
                if (ImageFile != null)
                {
                    //La taille est elle correcte ?
                    if (ImageFile.Length < 10000000) //Max 10mo
                    {
                        TempData["error"] = "Image trop lourde";
                        return View();
                    }
                    //Est ce une image ?
                    if (TypeAutorise.Contains(ImageFile.ContentType))
                    {
                        TempData["error"] = "Le format d'image n'est pas autorisé";
                        return View();
                    }
                }

                UserForm form = new UserForm();
                form.Id = HttpContext.Session.Get<int>("UserId");
                form.ImageFile = ImageFile;

                _userService.Update(form);
                TempData["success"] = "Modification effectuée";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Erreur d'enregistrement";
                return View();
            }
        }

        public IActionResult AddSkills()
        {
            UserForm form = _userService.GetById(HttpContext.Session.Get<int>("UserId"));

            if (form == null) return NotFound();
           
            form.SkillService = _skillService;
            return View(form);
        }

        [HttpPost]
        public IActionResult AddSkills(List<Skill> skills)
        {
            string[] MesChoix = this.Request.Form["ChoixSkill"].ToArray();
            UserForm form = new UserForm();

            form.SkillIds = new List<int>();
            foreach (string item in MesChoix)
            {
                form.SkillIds.Add(int.Parse(item));
            }

            if (ModelState.IsValid)
            {
                form.Id = HttpContext.Session.Get<int>("UserId");
                
                _userService.Update(form);
                TempData["success"] = "Modification effectuée";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Erreur d'enregistrement";
                return View();
            }
        }

        public IActionResult SkillById()
        {
            IEnumerable<NotationModel> model = _notationService.GetListById(HttpContext.Session.Get<int>("UserId"));

            return View(model);
        }
    }
}
