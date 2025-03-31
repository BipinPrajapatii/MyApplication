using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApplication.Core;
using MyApplication.Data.Entities;
using MyApplication.Repo;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using MyApplication.Service.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyApplication.Core.Model.User;
using MyApplication.Core.Model.Account;

namespace MyApplication.Service.Services
{
    public interface IUserService
    {
        Task<bool> SaveHistory(HistoryModel model);
        Task<bool> ChangeRole(string id, string role);
        Task<bool> Update(AppUserEditModel model);
        Task<bool> Insert(AppUserAddModel model);
        Task<bool> UpdateLoginStatus(bool isLoggedIn, string userId);
        public User GetEmail(string id);
        

    }

    public class UsersService : BaseService, IUserService
    {
        private IConfiguration configuration;
        private IEmailSender _emailSender;
        private readonly IUnitOfWork _uow;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UsersService(IUnitOfWork uow, UserManager<User> userManager, IConfiguration iConfig, IEmailSender emailSender,
        SignInManager<User> signInManager, UserResolverService userResolverService) : base(userResolverService)
        {
            _uow = uow;
            _userManager = userManager;
            _signInManager = signInManager;
            configuration = iConfig;
            _emailSender = emailSender;
        }

        public async Task<bool> SaveHistory(HistoryModel model)
        {
            History history = new History();

            history.Activity = model.Activity;
            history.CreatedOn = model.CreatedOn;
            history.UserId = model.UserId == null ? this.UserId : model.UserId;

            await _uow.HistoryRepository.Add(history);

            return await _uow.Save();
        }
        public User GetEmail(string id)
        {
            var user = _uow.UserRepository.Query().Where(x => x.Id == id).FirstOrDefault();

            return user;
        }
       

        public async Task<AppUserEditModel> GetForEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var result = new AppUserEditModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return result;
        }

        public async Task<bool> Update(AppUserEditModel model)
        {

            var user = await _userManager.FindByIdAsync(model.Id);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            if (!string.IsNullOrEmpty(model.NewPassword))
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.NewPassword);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return true;
            return false;
        }

        public async Task<bool> UpdateEmailConfirmation(AppUserEditModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            user.EmailConfirmed = false;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.NewPassword);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return true;
            return false;
        }
      

         public async Task<bool> Insert(AppUserAddModel model)
        {
            var newUser = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = model.IsEmailConfirmed
            };
            var result = await _userManager.CreateAsync(newUser, model.Password);
            _ = await _userManager.AddToRoleAsync(newUser, "User");

            if (result.Succeeded)
                return true;
            else
                return false;
        }


        public async Task<IEnumerable<SelectListItem>> GetLookupUsers()
        {
            var result = await _uow.UserRepository.Query().Select(x =>
                 new SelectListItem
                 {
                     Value = x.Id.ToString(),
                     Text = x.UserName
                 }).ToListAsync();

            return result;
        }

        public async Task<bool> ChangeRole(string id, string role)
        {
            User user = await _userManager.FindByIdAsync(id);
            var userRole = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRoleAsync(user, userRole.First());
            var result = await _userManager.AddToRoleAsync(user, role);
            if (result.Succeeded)
                return true;
            return false;
        }

       
        
    

    /*public async Task<bool> sendEmail(string email)
    {
        User user;
            user = new User();
            user.FirstName = "";
            user.LastName = "";
            user.UserName = email;
            user.Email = email;
            user.CompanyId = Convert.ToInt32(this.CompanyId);
            var result = await _userManager.CreateAsync(user);


        var users =
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        //Fetching Email Body Text from EmailTemplate File.
        *//*            string FilePath = Path.Combine(_environment.WebRootPath, "HtmlTemplate\\", "ForgotPassword.html");
                    StreamReader str = new StreamReader(FilePath);
                    string emailText = str.ReadToEnd();
                    str.Close();*//*


        var callback = Url.Action("ResetPassword", "User", new { token, email = user.Email }, Request.Scheme);

        emailText = emailText.Replace("{{Link}}", callback);

        var isEmailSent = _emailSender.SendEmail(new EmailModel(user.Email, "Your link to reset password in Marketing Manager", emailText, true));






        *//*    var To = email;
            var Subject = "Invitation for joining the team";
            var Message = "<h1><a href='#'>Click here</a>";
            var IsBodyHtml = true;
            var emailModel = new EmailModel( To, Subject, Message, IsBodyHtml );
            try
            {
                _emailSender.SendEmail(emailModel);
                return true;
            }
            catch (Exception ex)
            {

              return  false;
            }*//*

    }*/   
       

        public async Task<bool> UpdateLoginStatus(bool isLoggedIn, string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                userId = this.UserId;
            }

            var user = await _uow.UserRepository.Get(userId);
            user.IsLoggedIn = isLoggedIn;
            return await _uow.Save();
        }
    }
}

