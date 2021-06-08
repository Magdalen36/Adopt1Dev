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
    public class SkillService : IService<SkillModel, SkillForm>
    {

        private readonly DataContext _dc;

        public SkillService(DataContext dc)
        {
            _dc = dc;
        }

        public bool Delete(int id)
        {
            Skill toDelete = _dc.Skills.FirstOrDefault(x => x.Id == id);
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

        public IEnumerable<SkillModel> GetAll()
        {                    
            IEnumerable<Skill> allSkills = _dc.Skills;
            return allSkills.Select(s => new SkillModel { Id = s.Id, Name = s.Name });
        }

        public SkillForm GetById(int id)
        {
            Skill toUpdate = _dc.Skills.Find(id); //Methode de EntityFramework

            if (toUpdate != null)
            {
                return new SkillForm
                {
                    Id = toUpdate.Id,
                    Name = toUpdate.Name,                   
                };
            }
            else
            {
                return null;
            }
        }

        public void Insert(SkillForm form)
        {
            Skill s = new Skill
            {
                Id = form.Id,
                Name = form.Name,                
            };

            _dc.Skills.Add(s);
            _dc.SaveChanges();
        }

        public void Update(SkillForm form)
        {
            Skill s = _dc.Skills.Find(form.Id);
            s.Name = form.Name;
            _dc.SaveChanges();
        }
    }
}
