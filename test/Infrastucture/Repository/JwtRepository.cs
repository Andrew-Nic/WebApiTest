using CQRStest.Domain;
using CQRStest.Infrastucture.Persistence;
using System.Security.Claims;

namespace CQRStest.Infrastucture.Repository
{
    public class JwtRepository
    {
        private readonly AppDbContext _context;

        public JwtRepository(AppDbContext context)
        {
            _context = context;
        }

        public dynamic ValidToken(ClaimsIdentity identity)
        {
            try
            {
                if (identity.Claims.Count() == 0)
                {
                    return new
                    {
                        success = false,
                        message = "Verificar Token",
                        result = ""
                    };
                }

                var id = identity.Claims.FirstOrDefault(x => x.Type == "id").Value;
                User user = _context.Users.FirstOrDefault(x => x.Id.ToString() == id);

                return new
                {
                    success = true,
                    message = "Exito",
                    result = user
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    success = false,
                    message = "Catch: " + ex.Message,
                    result = ""
                };
            }
        }
    }
}
