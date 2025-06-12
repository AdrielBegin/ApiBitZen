using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TesteTecnico.Application.Autenticacao.Common.Interfaces;
using TesteTecnico.Domain.Entidades;

namespace TesteTecnico.Persistence.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IConfiguration _configuration;

        public AutenticacaoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool VerificarSenha(string senha, byte[] senhaHash, byte[] senhaSalt)
        {
            using var hmac = new HMACSHA512(senhaSalt);
            var hashComputado = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
            for (int i = 0; i < hashComputado.Length; i++)
            {
                if (hashComputado[i] != senhaHash[i]) return false;
            }
            return true;
        }

        public void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt)
        {
            using var hmac = new HMACSHA512();
            senhaSalt = hmac.Key;
            senhaHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
        }

        public string GerarToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Email.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Nome.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = _configuration["Jwt:Issuer"],       
                Audience = _configuration["Jwt:Audience"],   
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
