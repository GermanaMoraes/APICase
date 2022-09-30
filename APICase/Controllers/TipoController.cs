using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APICase.Models;
using APICase.Interface;

namespace APICase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {
        private readonly ITipoUsuario repositorio;

        public TipoController(ITipoUsuario _repositorio)
        {
            repositorio = _repositorio;
        }


        /// <summary>
        /// Listar todos os tipos de usuários.
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
        /// Buscar um tipo de usuário por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarTipoporId(int id)
        {
            try
            {
                var retorno = repositorio.GetById(id);
                if (retorno == null)
                {
                    return NotFound(new { Message = " Tipo não encontrado." });
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
    }
}


