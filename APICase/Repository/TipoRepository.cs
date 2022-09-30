using APICase.Data;
using APICase.Interface;
using APICase.Models;
using System.Collections.Generic;
using System.Linq;

namespace APICase.Repository
{
    public class TipoRepository : ITipoUsuario
    {
        ClinicaContext ctx;

        public TipoRepository(ClinicaContext _ctx)
        {
            ctx = _ctx;
        }
        public ICollection<TipoUsuario> GetAll()
        {
            return ctx.TipoUsuarios.ToList();
        }

        public TipoUsuario GetById(int id)
        {
            return ctx.TipoUsuarios.Find(id);
        }
    }
}
