using APICase.Data;
using APICase.Interface;
using APICase.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace APICase.Repository
{
    public class ConsultaRepository : IConsulta
    {
        ClinicaContext ctx;

        public ConsultaRepository(ClinicaContext _ctx)
        {
            ctx = _ctx;
        }

        public void Delete(Consulta consulta)
        {
            ctx.Consulta.Remove(consulta);
            ctx.SaveChanges();
        }

        public ICollection<Consulta> GetAll()
        {
            return ctx.Consulta.ToList();
        }

        public Consulta GetById(int id)
        {
            return ctx.Consulta.Find(id);
        }

        public Consulta Insert(Consulta consulta)
        {
            ctx.Consulta.Add(consulta);
            ctx.SaveChanges();
            return consulta;
        }

        public void Update(Consulta consulta)
        {
            ctx.Entry(consulta).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void UpdatePatch(JsonPatchDocument patchconsulta, Consulta consulta)
        {
            patchconsulta.ApplyTo(consulta);
            ctx.Entry(consulta).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
