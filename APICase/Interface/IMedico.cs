using APICase.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace APICase.Interface
{
    public interface IMedico
    {
        //Inserir Medico
        Medico Insert(Medico medico);

        //Listar todas os médicos
        ICollection<Medico> GetAll();

        //Consultar por Id
        Medico GetById(int id);

        //Alterar a Consulta
        void Update(Medico medico);

        //Deletar a Consulta
        void Delete(Medico medico);

        //Update com Patch
        void UpdatePatch(JsonPatchDocument patchconsulta, Medico medico);
    }
}
