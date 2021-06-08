using Adopt1Dev.ASP.Models;
using Adopt1Dev.ASP.Models.Form;
using Adopt1Dev.DAL;
using Adopt1Dev.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Adopt1Dev.ASP.Services
{
    public class UserService : IService<UserModel, UserForm>
    {

        private readonly DataContext _dc;

        public UserService(DataContext dc)
        {
            _dc = dc;
        }

        public bool Delete(int id)
        {
            User toDelete = _dc.Users.FirstOrDefault(x => x.Id == id);
            if (toDelete == null)
            {
                return false;
            }
            else
            {
                _dc.Remove(toDelete);
                _dc.SaveChanges();
                return true;
            }
        }

        public IEnumerable<UserModel> GetAll()
        {
            IEnumerable<User> allUsers = _dc.Users;
            return allUsers.Select(u => new UserModel { Id = u.Id, Email = u.Email });
        }

        public UserForm GetById(int id)
        {
            User toUpdate = _dc.Users.Find(id);
            if (toUpdate != null)
            {
                return new UserForm
                {
                    Id = toUpdate.Id,
                    Email = toUpdate.Email,

                };
            }
            else
            {
                return null;
            }
            //throw new NotImplementedException();
        }

        public void Insert(UserForm form)
        {
            UserModel model = new UserModel()
            {
                Email = form.Email,               
                PasswordIn = form.Password
            };

            User entity = new User()
            {
                Email = model.Email,               
                Password = model.PasswordOut
            };

            _dc.Users.Add(entity);
            _dc.SaveChanges();

            //PErmet de mettre l'id calculé par la db dans l'objet de départ (form)
            form.Id = entity.Id;
        }

        public void Update(UserForm form)
        {
            User model = _dc.Users.Find(form.Id);


            model.ImageMimeType = form.ImageFile?.ContentType;
            model.ImageFile = UploadMe(form.ImageFile);

            foreach (int skillId in form.SkillIds)
            {
                Notation n = new Notation() { UserId = form.Id, SkillId = skillId, Note = 7 };
                _dc.Notations.Add(n);
            }

            _dc.SaveChanges();

        }

        private byte[] UploadMe(IFormFile imageFile)
        {

            if (imageFile == null) return null;

            byte[] imageEnByte = null;
            //Upload en bytes, pas en fichier physique
            using (MemoryStream memoryStream = new MemoryStream())
            {
                imageFile.CopyTo(memoryStream);
                imageEnByte = memoryStream.ToArray();
            }
            return imageEnByte;
        }

    }
}
