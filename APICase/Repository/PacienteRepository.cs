using APICase.Data;
using APICase.Interface;
using APICase.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace APICase.Repository
{
    public class PacienteRepository : IPaciente
    {
        ClinicaContext ctx;

        public PacienteRepository(ClinicaContext _ctx)
        {
            ctx = _ctx;
        }

        public void Delete( Paciente paciente)
        {
            ctx.Pacientes.Remove(paciente);
            ctx.SaveChanges();
        }

        public ICollection<Paciente> GetAll()
        {
            return ctx.Pacientes.ToList();
        }

        public Paciente GetById(int id)
        {
            return ctx.Pacientes.Find(id);
        }

        public Paciente Insert(Paciente paciente)
        {
            ctx.Pacientes.Add(paciente);
            ctx.SaveChanges();
            return paciente;
        }

        public void Update(Paciente paciente)
        {
            ctx.Entry(paciente).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void UpdatePatch(JsonPatchDocument patchpaciente, Paciente paciente)
        {
            patchpaciente.ApplyTo(paciente);
            ctx.Entry(paciente).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
