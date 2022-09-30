using APICase.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace APICase.Interface
{
    public interface IConsulta
    {

        //Inserir Consulta
        Consulta Insert(Consulta consulta);

        //Listar todas as consultas
        ICollection<Consulta> GetAll();

        //Consultar por Id
        Consulta GetById(int id);

        //Alterar a Consulta
        void Update(Consulta consulta);

        //Deletar a Consulta
        void Delete(int id);

        //Update com Patch
        void UpdatePatch(JsonPatchDocument patchconsulta, Consulta consulta);
    }
}
