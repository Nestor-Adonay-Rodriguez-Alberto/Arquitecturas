using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Web_API.Handlers.Empleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        // Para Acceder a la Key:
        private IConfiguration _Configuration;

        public AutenticacionController(IConfiguration configuration) 
        {
            _Configuration = configuration;
        } 


        [HttpPost("Login")]
        public async Task<IActionResult> Login()
        {
            string Token_Seguro = Generar_Token();

            return Ok(Token_Seguro);
        }


        private string Generar_Token()
        {
            // DATOS DEL EMPLEADO:
            Claim[] Claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, "Nestor"),
                new Claim("Rol", "Developer"),
            };

            byte[] keyBytes = new byte[64]; // 64 bytes = 512 bits
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(keyBytes);
            }

            // OBTENGO EN BYTES LA KEY:
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Key"]));

            // ENCRIPTAMOS LA KEY:
            var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);

            // CREAMOS EL TOKEN:
            JwtSecurityToken Token_Seguro = new JwtSecurityToken(
                claims: Claims,
                expires: DateTime.Now.AddHours(8),
                signingCredentials: Creds
                );

            // Formatemos el Token:
            string Token = new JwtSecurityTokenHandler().WriteToken(Token_Seguro);

            return Token;
        }

    }
}
