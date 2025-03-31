using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MyApplication.Data.Entities;
using MyApplication.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Service
{
    public class AdditionalUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, IdentityRole>
    {
        private readonly IUnitOfWork _uow;
        public AdditionalUserClaimsPrincipalFactory(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options, IUnitOfWork uow) : base(userManager, roleManager, options)
        {
            _uow = uow;
        }
        public async override Task<ClaimsPrincipal> CreateAsync(User user)
        {

            var principal = await base.CreateAsync(user);
            var identity = (ClaimsIdentity)principal.Identity;
            //user.Company = await _uow.CompanyRepository.Get(user.CompanyId);
            //var tempAccess = _uow.AccessReportSettingRepository.Query().FirstOrDefault(x => x.CompanyId == user.CompanyId);
            //var location = _uow.TrackingSettingRepository.Query().FirstOrDefault(x => x.UserId == user.Id);

            var claims = new List<Claim>
            {
                new Claim("UserId", user.Id),
                new Claim("FullName", user.FirstName + " " + user.LastName),
               //new Claim(ClaimTypes.Email, user.Email),
                //new Claim("CompanyId",user.CompanyId.ToString()),
                //new Claim("CompanyName",user.Company.Name),
                //new Claim("SeeReports",tempAccess.SeeReports.ToString()),
                //new Claim("SeeScreenshots",tempAccess.SeeScreenshots.ToString()),
                //new Claim("LocationTracking",location.LocationTracking.ToString()),
            };

            identity.AddClaims(claims);
            return principal;
        }
    }
}
