using CQRStest.Application.DTOs.UsersDTO;
using CQRStest.Domain;
using CQRStest.Domain.Jwt;
using CQRStest.Infrastucture.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;

namespace CQRStest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;
        public LoginController(AppDbContext appDbContext, IConfiguration configuration) 
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
        }
        
        [HttpPost]
        public ActionResult Login(LoginUser loginUser)
        {
            var user = _appDbContext.Users.
                FirstOrDefault(us =>
                    us.PublicAccess == loginUser.Username && 
                    us.PasswordAccess == loginUser.Password);
            if (user == null)
            {
                return NotFound();
            }
            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("id",user.Id.ToString(), ClaimValueTypes.Integer),
                new Claim("username", user.PublicAccess.ToString())
            };

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var SingIn = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken
                (
                    jwt.Issuer,
                    jwt.Audience,
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(60),
                    signingCredentials: SingIn
                );
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }


        [HttpGet("[Action]")]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _appDbContext.Users.Select(user => new
            {
                user.Id,
                user.Name,
                user.Email,
                Permiso = user.Permission.Name,
                modules = user.Permission.Modules.Select(module => module.Name)
            }).ToListAsync();
            return Ok(users);
        }
    }
}
