namespace MyApplication.Service.Services
{
    public abstract class BaseService
    {
        protected int CompanyId;
        protected string UserId;
        protected string FullName;
        protected string UserRole;

        public BaseService(UserResolverService userResolverService)
        {
            var userClaim = userResolverService.GetUser();
            CompanyId = userClaim.GetCompanyId();
            UserId = userClaim.GetUserId();
            FullName = userClaim.GetFullName();
            UserRole = userClaim.GetUserRole();
        }
    }
}
