using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DynamicLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApplication.Core;
using MyApplication.Data.Entities;
using MyApplication.Repo;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MyApplication.Service.Services
{
    public interface ICompanyService
    {
        Task<List<CompanyListModel>> GetAll();
        Task<bool> Delete(int id);
        Task<CompanyAddEditModel> Get(int id);
        Task<bool> Save(CompanyAddEditModel model);
        Task<IEnumerable<SelectListItem>> GetLookup();
        Task<bool> UpdateLastSyncDateAsync(DateTime? LastSyncedDateTime);
    }
    public class CompanyService : BaseService, ICompanyService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public CompanyService(IUnitOfWork uow, IMapper mapper, UserResolverService userResolverService, UserManager<User> userManage) : base(userResolverService)
        {
            _uow = uow;
            _mapper = mapper;
            _userManager = userManage;
        }       


        public async Task<List<CompanyListModel>> GetAll()
        {
            return _mapper.Map<List<CompanyListModel>>(await _uow.CompanyRepository.GetAll());
        }

        public async Task<bool> Delete(int id)
        {

            await _uow.CompanyRepository.Delete(id);
            return await _uow.Save();
        }

        public async Task<CompanyAddEditModel> Get(int id)
        {
            return _mapper.Map<CompanyAddEditModel>(await _uow.CompanyRepository.Get(id));
        }

        public async Task<bool> Save(CompanyAddEditModel model)
        {
            Company entity;
            User user;
            entity = _mapper.Map<Company>(model);
            if (model.Id == 0)
            {
                user = new User();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.UserName = model.Email;
                user.EmailConfirmed = true;
                entity.CreatedOn = DateTime.UtcNow;
                await _uow.CompanyRepository.Add(entity);
                await _uow.Save();

                user.CompanyId = Convert.ToInt32(entity.Id);
                
                await _uow.Save();

                var result = await _userManager.CreateAsync(user, "Password@123");
                if (result.Succeeded)
                {
                    result = await _userManager.AddToRoleAsync(user, "Admin");
                    if (result.Succeeded)
                        return true;
                }

            }
            else
            {
                entity.UpdatedOn = DateTime.UtcNow;
                user = await _userManager.FindByEmailAsync(model.Email);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                await _uow.CompanyRepository.Update(entity);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return await _uow.Save();
                }
            }

            return false;
        }

        public async Task<IEnumerable<SelectListItem>> GetLookup()
        {
            var result = await _uow.CompanyRepository.Query().Select(x =>
                new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToListAsync();

            return result;
        }

        public async Task CreateDemoCompany()
        {
            var entity = new Company()
            {
                Address1 = "Address Line 1",
                Address2 = "Address Line 2",
                City = "Surat",
                Country = "India",
                Email = "noemail@noemail.com",
                EndDate = DateTime.UtcNow.AddDays(365),
                FirstName = "Contact",
                LastName = "Name",
                MaxUser = 5,
                Id = 1,
                Name = "Demo Company",
                PhoneNo = "1234567890",
                StartDate = DateTime.UtcNow,
                State = "Gujarat",
                ZipCode = "395000"
            };
            await _uow.CompanyRepository.Add(entity);
            await _uow.Save();
        }

        public async Task<bool> UpdateLastSyncDateAsync(DateTime? LastSyncedDateTime)
        {
            var company = await _uow.CompanyRepository.Get(CompanyId);
            company.LastSyncedDateTime = LastSyncedDateTime;
            return await _uow.Save();
        }
    }
}
