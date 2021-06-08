using Adopt1Dev.ASP.Models;
using Adopt1Dev.ASP.Models.Form;
using Adopt1Dev.DAL;
using Adopt1Dev.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adopt1Dev.ASP.Services
{
    public class NotationService : IService<NotationModel, NotationForm>
    {

        private readonly DataContext _dc;

        public NotationService(DataContext dc)
        {
            _dc = dc;
        }

        public bool Delete(int d)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NotationModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public NotationForm GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(NotationForm form)
        {
            throw new NotImplementedException();
        }

        public void Update(NotationForm form)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NotationModel> GetListById(int id)
        {
            IEnumerable<Notation> allNotations = _dc.Notations.Where(n => n.Id == id);
            return allNotations.Select(n => new NotationModel { Id = n.Id, SkillId = n.SkillId, UserId = n.UserId, Note = n.Note });
        }    

    }
}
