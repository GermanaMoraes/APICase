using APICase.Data;
using APICase.Interface;
using APICase.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace APICase.Repository
{
    public class EspecialidadeRepository : IEspecialidade
    {
        ClinicaContext ctx;

        public EspecialidadeRepository(ClinicaContext _ctx)
        {
            ctx = _ctx;
        }
        public void Delete(Especialidade especialidade)
        {
            ctx.Especialidades.Remove(especialidade);
            ctx.SaveChanges();
        }

        public ICollection<Especialidade> GetAll()
        {
            return ctx.Especialidades.ToList();
        }

        public Especialidade GetById(int id)
        {
            return ctx.Especialidades.Find(id);
        }

        public Especialidade Insert(Especialidade especialidade)
        {
            ctx.Especialidades.Add(especialidade);
            ctx.SaveChanges();
            return especialidade;
        }

        public void Update(Especialidade especialidade)
        {
            ctx.Entry(especialidade).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void UpdatePatch(JsonPatchDocument patchespecialidade, Especialidade especialidade)
        {
            patchespecialidade.ApplyTo(especialidade);
            ctx.Entry(especialidade).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
