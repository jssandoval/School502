using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using school.Core.Entities;
using school.Core.Exceptions;
using school.Core.Interfaces;
using school.Infrastructure.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace school.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IPasswordService _passwordService;
        private readonly ISecurityService _securityService;

        public TokenController(IConfiguration configuration, IPasswordService passwordService, ISecurityService securityService)
        {
            _configuration = configuration;
            _passwordService = passwordService;
            _securityService = securityService;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Authentication([FromBody] UserLogin login)
        {
            //if it is valid user
            var validation = await IsValidUser(login);
            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                return Ok(new { token  });
            }
            return NotFound();
        }

        private async Task<(bool, User)> IsValidUser(UserLogin login)
        {
            var hash = _passwordService.Hash(login.Password + login.User);
            var user = await _securityService.GetLoginByCredentials(login);
            if (user == null)
            {
                throw new BusinessException("User not valid");
            }
            var isValid = _passwordService.Check(user.Password, login.Password + login.User);
            if (!isValid)
            {
                throw new BusinessException("Password not valid");
            }
            return (isValid, user);
        }

        private string GenerateToken(User security)
        {
            //Header
            var symetricSecuriyKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symetricSecuriyKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, security.Name),
                new Claim(ClaimTypes.Email, security.Email),
                new Claim(ClaimTypes.Role, "Administrador")
            };

            //Playload
            var payload = new JwtPayload
            (
                issuer: _configuration["Authentication:Issuer"],
                audience: _configuration["Authentication:Audience"],
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["Authentication:expireTime"]))  //ojo configurable
            );

            //Token Signature
            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
