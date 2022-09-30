using APICase.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace APICase.Interface
{
    public interface IEspecialidade
    {

        //Inserir Especialidade
        Especialidade Insert(Especialidade especialidade);

        //Listar todas as especialidades
        ICollection<Especialidade> GetAll();

        //Consultar por Id
        Especialidade GetById(int id);

        //Alterar a Especialidade
        void Update(Especialidade especialidade);

        //Deletar a Especialidade
        void Delete(Especialidade especialidade);

        //Update com Patch
        void UpdatePatch(JsonPatchDocument patchespecialidade, Especialidade especialidade);



    }
}
