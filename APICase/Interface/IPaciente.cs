using APICase.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
namespace APICase.Interface
{
    public interface IPaciente
    {

        //Inserir Paciente
        Paciente Insert(Paciente paciente);

        //Listar todos os pacientes
        ICollection<Paciente> GetAll();

        //Consultar por Id
        Paciente GetById(int id);

        //Alterar a Consulta
        void Update(Paciente paciente);

        //Deletar a Consulta
        void Delete(Paciente paciente);

        //Update com Patch
        void UpdatePatch(JsonPatchDocument patchpaciente, Paciente paciente);
    }
}
