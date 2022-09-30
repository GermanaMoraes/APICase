using APICase.Data;
using APICase.Interface;
using APICase.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace APICase.Repository
{
    public class ConsultaRepository : IConsulta
    {
        ClinicaContext ctx;

       public ConsultaRepository(ClinicaContext _ctx)
        {
            ctx=  _ctx;
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Consulta> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Consulta GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Consulta Insert(Consulta consulta)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Consulta consulta)
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePatch(JsonPatchDocument patchconsulta, Consulta consulta)
        {
            throw new System.NotImplementedException();
        }
    }
}
