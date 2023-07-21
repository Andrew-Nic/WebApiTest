using CQRStest.Infrastucture.Persistence;
using CQRStest.Infrastucture.Repository;
using System.Security.Claims;

namespace CQRStest.Application.Services
{
    public class LoginService
    {
        private JwtRepository _JwtRepository { get; set; }
        private readonly AppDbContext _appDbContext;

        public LoginService(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
            _JwtRepository = new JwtRepository(_appDbContext);
        }

        public dynamic ValidToken(ClaimsIdentity identity)
        {
            return _JwtRepository.ValidToken(identity);
        }
    }
}
