using APICase.Data;
using System.Linq;

namespace APICase.Repository
{
    public class LoginRepository
    {

        private readonly ClinicaContext ctx;
        public LoginRepository(ClinicaContext _ctx)
        {
            ctx = _ctx;
        }

        public string Logar(string email, string senha)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == email);

            if (usuario != null)
            {
                bool confere = BCrypt.Net.BCrypt.Verify(senha, usuario.Senha);
                if (confere)
                {
                    //Criar as credências JWT

                    //definir as Claims

                    var myClaims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Role, "Adm"),
                        new Claim ("Cargo", "Adm")
                    };
                    //Criando a chave
                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("DesafioCase-chave-autenticacao"));

                    //Criando as credênciais
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    //Gerar Token

                    var myToken = new JwtSecurityToken(
                        issuer: "DesafioCase.webAPI",
                        audience: "DesafioCase.webAPI",
                        claims: myClaims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                        );

                    return new JwtSecurityTokenHandler().WriteToken(myToken);


                }


            }

            return null;

        }
    }
}

