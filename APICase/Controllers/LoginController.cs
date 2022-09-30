using APICase.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILogin repo;

        public LoginController(ILogin _repo)
        {
            repo = _repo;
        }


        [HttpPost]
        public IActionResult Logar(string email, string senha)
        {
            var logar = repo.Logar(email, senha);
            if (logar == null)
                return Unauthorized();

            return Ok(new { token = logar });
        }
    }
}



