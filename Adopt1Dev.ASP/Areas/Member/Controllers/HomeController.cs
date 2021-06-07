
using Adopt1Dev.ASP.Models;
using Adopt1Dev.ASP.Models.Form;
using Adopt1Dev.ASP.Services;
using Adopt1Dev.ASP.Tools;
using Microsoft.AspNetCore.Authorization;
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

        public HomeController(IService<UserModel, UserForm> userService)
        {
            _userService = userService;
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
            return View();
        }

        [HttpPost]
        public IActionResult AddPicture(UserForm form)
        {

            //form.UserService = _userService;
            form.Id = HttpContext.Session.Get<int>("Id");

            if (ModelState.IsValid)
            {
                string[] TypeAutorise = { "image/jpeg", "image/jpg", "image/png", "image/gif" };
                byte[] imageEnByte = null;

                //Check notre fichier
                //Est ce qu'on a un fichier ?
                if (form.ImageFile != null)
                {
                    //La taille est elle correcte ?
                    if (form.ImageFile.Length < 10000000) //Max 10mo
                    {
                        TempData["error"] = "Image trop lourde";
                        return View(form);
                    }
                    //Est ce une image ?
                    if (TypeAutorise.Contains(form.ImageFile.ContentType))
                    {
                        TempData["error"] = "Le format d'image n'est pas autorisé";
                        return View(form);
                    }
                }

                _userService.Update(form);
                TempData["success"] = "Modification effectuée";
                return RedirectToAction("Index");
            }
            else 
            {
                TempData["Error"] = "Erreur d'enregistrement";
                return View(form);
            }
               
        }
    }
}
