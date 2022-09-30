using APICase.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
namespace APICase.Interface
{
    public interface ITipoUsuario
    {

        //Listar todas os tipos 
        ICollection<TipoUsuario> GetAll();

        //Consultar por Id
        TipoUsuario GetById(int id);

        
    }
}
