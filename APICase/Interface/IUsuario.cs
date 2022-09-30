using APICase.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
namespace APICase.Interface
{
    public interface IUsuario
    {
        //Inserir Usuário
        Usuario Insert(Usuario usuario);

        //Listar todos os usuários
        ICollection<Usuario> GetAll();

        //Consultar por Id
        Usuario GetById(int id);

        //Alterar o Usuário
        void Update(Usuario usuario);

        //Deletar o Usuário
        void Delete(Usuario usuario);

        //Update com Patch
        void UpdatePatch(JsonPatchDocument patchUsuario, Usuario usuario);
    }
}
