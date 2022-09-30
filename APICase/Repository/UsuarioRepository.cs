using APICase.Data;
using APICase.Interface;
using APICase.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace APICase.Repository
{
    public class UsuarioRepository : IUsuario
    {
        ClinicaContext ctx;

        public UsuarioRepository(ClinicaContext _ctx)
        {
            ctx = _ctx;
        }
        public void Delete(Usuario usuario)
        {
            ctx.Usuarios.Remove(usuario);
            ctx.SaveChanges();
        }

        public ICollection<Usuario> GetAll()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario GetById(int id)
        {
            return ctx.Usuarios.Find(id);
        }

        public Usuario Insert(Usuario usuario)
        {
            ctx.Usuarios.Add(usuario);
            ctx.SaveChanges();
            return usuario;
        }

        public void Update(Usuario usuario)
        {
            ctx.Entry(usuario).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void UpdatePatch(JsonPatchDocument patchUsuario, Usuario usuario)
        {
            patchUsuario.ApplyTo(usuario);
            ctx.Entry(usuario).State = EntityState.Modified;
            ctx.SaveChanges();

        }
    }
}
