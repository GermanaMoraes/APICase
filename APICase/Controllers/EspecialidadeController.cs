using APICase.Interface;
using APICase.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace APICase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidade repositorio;

        public EspecialidadeController(IEspecialidade _repositorio)
        {
            repositorio = _repositorio;
        }


        /// <summary>
        /// Cadastrar uma Especialidade no banco de dados.
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Especialidade especialidade)
        {
            try
            {
                var retorno = repositorio.Insert(especialidade);
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
        /// Listar todas as especialidades
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
        /// Buscar uma especialidad por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarConsultaporId(int id)
        {
            try
            {
                var retorno = repositorio.GetById(id);
                if (retorno == null)
                {
                    return NotFound(new { Message = " Especialidade não encontrada" });
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
        /// Alterar uma consulta.  É necessário implementar o Id na aplicação.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="consulta"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Alterar(int id, Especialidade especialidade)
        {
            try
            {
                //Verificar se os ids batem
                if (id != especialidade.Id)
                {
                    return BadRequest();
                }

                //Verificar se o id existe no banco
                var retorno = repositorio.GetById(id);
                if (retorno == null)
                {
                    return NotFound(new
                    {
                        Message = " Consulta não encontrada"
                    });
                }
                //Alterar
                repositorio.Update(especialidade);
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
        /// Alterar algo específico na Consulta. Modelo: "op", "path", "value".
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchConsulta"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [Authorize]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument patchEspecialidade)
        {
            try
            {
                if (patchEspecialidade == null)
                { return BadRequest(); }

                var especialidade = repositorio.GetById(id);
                if (especialidade == null)
                {
                    return NotFound(new { Message = "Especialidade não encontrada." });
                }
                repositorio.UpdatePatch(patchEspecialidade, especialidade);


                return Ok(especialidade);


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
        /// Deletar uma Consulta.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = repositorio.GetById(id);
                if (item == null)
                {
                    return NotFound();
                }
                repositorio.Delete(item);
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
    

