using APICase.Interface;
using APICase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace APICase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ConsultumController : ControllerBase
        {
            private readonly IConsulta repositorio;

            public ConsultumController(IConsulta _repositorio)
            {
                repositorio = _repositorio;
            }


            /// <summary>
            /// Cadastrar uma Consulta no banco de dados.
            /// </summary>
            /// <param name="consulta"></param>
            /// <returns></returns>
            [HttpPost]
            public IActionResult Cadastrar(Consulta consulta)
            {
                try
                {
                    var retorno = repositorio.Insert(consulta);
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
            /// Listar todas as consultas
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
            /// Buscar uma consulta por Id.
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
                        return NotFound(new { Message = " Consulta não encontrada" });
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
            public IActionResult Alterar(int id, Consulta consulta)
            {
                try
                {
                    //Verificar se os ids batem
                    if (id != consulta.Id)
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
                    repositorio.Update(consulta);
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
            public IActionResult Patch(int id, [FromBody] JsonPatchDocument patchConsulta)
            {
                try
                {
                    if (patchConsulta == null)
                    { return BadRequest(); }

                    var consulta = repositorio.GetById(id);
                    if (consulta == null)
                    {
                        return NotFound(new { Message = "Consulta não encontrada." });
                    }
                    repositorio.UpdatePatch(patchConsulta, consulta);
                    

                    return Ok(consulta);


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
}
