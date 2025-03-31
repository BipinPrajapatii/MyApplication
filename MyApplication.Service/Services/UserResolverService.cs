using Microsoft.AspNetCore.Http;

namespace MyApplication.Service.Services
{
    public class UserResolverService
    {
        private readonly IHttpContextAccessor _context;

        public UserResolverService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public System.Security.Principal.IIdentity GetUser()
        {
            return _context.HttpContext.User?.Identity;
        }
    }
}