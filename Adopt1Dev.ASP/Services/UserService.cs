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

        public bool Delete(int d)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserForm GetById(int id)
        {
            throw new NotImplementedException();
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
