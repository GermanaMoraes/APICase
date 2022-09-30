using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository repositorio;

        public UsuarioController(IUsuarioRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        /// <summary>
        /// Cadastrar um Usuário no banco de dados.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                var retorno = repositorio.Insert(usuario);
                return Ok(retorno);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    Erro = "Falha na Transação",
                    Message = ex.Message
                });
            }
        }


        /// <summary>
        /// Listar todas os Usuários.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var retorno = repositorio.GetAll();
                return Ok(retorno);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    Erro = "Falha na Transação",
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Buscar um Usuário por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarConsultaporId(int id)
        {
            try
            {
                var retorno = repositorio.GetbyId(id);
                if (retorno == null)
                {
                    return NotFound(new { Message = "Usuario não encontrado" });
                }

                return Ok(retorno);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    Erro = "Falha na Transação",
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Alterar um Usuário. É necessário implementar o Id na aplicação.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Usuario usuario)
        {
            try
            {
                //Verificar se os ids batem
                if (id != usuario.Id)
                {
                    return BadRequest();
                }

                //Verificar se o id existe no banco
                var retorno = repositorio.GetbyId(id);
                if (retorno == null)
                {
                    return NotFound(new
                    {
                        Message = " Consulta não encontrada"
                    });
                }
                //Alterar
                repositorio.Update(usuario);
                return NoContent();
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, new
                {
                    Erro = "Falha na Transação",
                    Message = ex.Message
                });
            }

        }

        /// <summary>
        ///Alterar algo específico no Usuário. Modelo: "op", "path", "value".
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchUsuario"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument patchUsuario)
        {
            try
            {
                if (patchUsuario == null)
                { return BadRequest(); }

                var usuario = repositorio.GetbyId(id);
                if (usuario == null)
                {
                    return NotFound(new { Message = "Usuário não encontrado." });
                }

                repositorio.UpdateParcial(patchUsuario, usuario);

                return Ok(usuario);


            }
            catch (System.Exception ex)
            {

                return StatusCode(500, new
                {
                    Erro = "Falha na Transação",
                    Message = ex.Message
                });
            }
        }


        /// <summary>
        /// Deletar um Usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                var buscar = repositorio.GetbyId(id);
                if (buscar == null)
                {
                    return NotFound(new { Message = "Usuário não encontrado." });
                }

                repositorio.Delete(buscar);
                return NoContent();

            }
            catch (System.Exception ex)
            {

                return StatusCode(500, new
                {
                    Erro = "Falha na Transação",
                    Message = ex.Message
                });
            }
        }



    }
}








    
    }
}
