using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APICase.Interface;
using APICase.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;

namespace APICase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {

        private readonly IPaciente repositorio;

        public PacienteController(IPaciente _repositorio)
        {
            repositorio = _repositorio;
        }


        /// <summary>
        /// Cadastrar um paciente no banco de dados.
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public IActionResult Cadastrar(Paciente paciente)
        {
            try
            {
                var retorno = repositorio.Insert(paciente);
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
        /// Listar todos os pacientes.
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
        /// Buscar um paciente por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPacienteporId(int id)
        {
            try
            {
                var retorno = repositorio.GetById(id);
                if (retorno == null)
                {
                    return NotFound(new { Message = " Paciente não encontrado." });
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
        /// Alterar um paciente.  É necessário implementar o Id na aplicação.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="medico"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Alterar(int id, Paciente paciente)
        {
            try
            {
                //Verificar se os ids batem
                if (id != paciente.Id)
                {
                    return BadRequest();
                }

                //Verificar se o id existe no banco
                var retorno = repositorio.GetById(id);
                if (retorno == null)
                {
                    return NotFound(new
                    {
                        Message = " Paciente não encontrado."
                    });
                }
                //Alterar
                repositorio.Update(paciente);
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
        /// Alterar algo específico no paciente. Modelo: "op", "path", "value".
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchMedico"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [Authorize]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument patch)
        {
            try
            {
                if (patch == null)
                { return BadRequest(); }

                var paciente = repositorio.GetById(id);
                if (paciente == null)
                {
                    return NotFound(new { Message = "Paciente não encontrada." });
                }
                repositorio.UpdatePatch(patch, paciente);


                return Ok(paciente);


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
        /// Deletar um Paciente.
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
