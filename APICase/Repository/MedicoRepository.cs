using APICase.Data;
using APICase.Interface;
using APICase.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace APICase.Repository
{
    public class MedicoRepository : IMedico
    {
        ClinicaContext ctx;

        public MedicoRepository(ClinicaContext _ctx)
        {
            ctx= _ctx;
        }
        public void Delete(Medico medico)
        {
            ctx.Medicos.Remove(medico);
            ctx.SaveChanges();
        }

        public ICollection<Medico> GetAll()
        {
            return ctx.Medicos.ToList();
        }

        public Medico GetById(int id)
        {
            return ctx.Medicos.Find(id);
        }

        public Medico Insert(Medico medico)
        {
            ctx.Medicos.Add(medico);
            ctx.SaveChanges();
            return medico;
        }

        public void Update(Medico medico)
        {
            ctx.Entry(medico).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void UpdatePatch(JsonPatchDocument patchmedico, Medico medico)
        {
            patchmedico.ApplyTo(medico);
            ctx.Entry(medico).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}