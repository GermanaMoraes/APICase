namespace APICase.Interface
{
    public interface ITipoUsuario
    {

        //Listar todas os tipos de usuários
        ICollection<Medico> GetAll();

        //Consultar por Id
        Medico GetById(int id);

        
    }
}
