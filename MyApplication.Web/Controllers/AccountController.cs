using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MyApplication.Core;
using MyApplication.Core.Model.Account;
using MyApplication.Core.Model.Email;
using MyApplication.Data.Entities;
using MyApplication.Service;
using MyApplication.Service.Services;
using MyApplication.Web.Models;


namespace TimeTrackingSoft.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IWebHostEnvironment _environment;
        //private readonly IEmailSender _emailSender;
       // private readonly IUserService _userService;
        public AccountController(UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              IWebHostEnvironment environment
                              //IEmailSender emailSender,
                              //IUserService userService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _environment = environment;
            //_emailSender = emailSender;
           // _userService = userService;
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    var result1 = await _signInManager.PasswordSignInAsync(user.Email, model.Password, false, false);
                    if (result1.Succeeded)
                        return RedirectToAction("index", "Home");
                    else
                        return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                      
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegisterCompany()
        {
            return View(new CompanyAddEditModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    var users = await _userManager.FindByEmailAsync(user.Email);
                    HistoryModel history = new HistoryModel
                    {
                        Activity = "Login",
                        CreatedOn = DateTime.UtcNow,
                        UserId = users.Id
                    };

                    //await _userService.SaveHistory(history);
                    return RedirectToAction("Index", "Dashboard");

                }

                ModelState.AddModelError("RememberMe", "Incorrect email address or password.");

            }
            return View(user);
        }
        public async Task<IActionResult> Logout()
        {
            HistoryModel history = new HistoryModel
            {
                Activity = "Logout",
                CreatedOn = DateTime.UtcNow
            };

            //await _userService.SaveHistory(history);
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ViewBag.ShowAlert = "Invalid email.";
                return View("ForgotPassword", model);
            }

            //Fetching Email Body Text from EmailTemplate File.  
            string FilePath = Path.Combine(_environment.WebRootPath, "HtmlTemplate\\", "ForgotPassword.html");
            StreamReader str = new StreamReader(FilePath);
            string emailText = str.ReadToEnd();
            str.Close();

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callback = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);

            emailText = emailText.Replace("{{Link}}", callback);

            var isEmailSent = false;// _emailSender.SendEmail(new EmailModel(user.Email, "Your link to reset password in Time Tracking Soft", emailText, true));
            if (!isEmailSent)
                ViewBag.ShowAlert = "Send email failed.";
            else
                ViewBag.ShowAlert = "Password reset link has been sent to your email.";
            return View();

        }

        private void IdentityResultErrors(IdentityResult result)
        {
            if (result.Errors.Count() > 0)
            {
                foreach (var error in result.Errors)
                {
                    ViewBag.ShowAlert += error.Description + Environment.NewLine;
                }
            }
        }

        public async Task<IActionResult> ResetPassword(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var model = new ResetPasswordViewModel { Token = token, Email = email, FirstName = user.FirstName, LastName = user.LastName };
            return View(model);
        }

        public async Task<IActionResult> ResetInvitationPassword(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var model = new ResetPasswordViewModel { Token = token, Email = email, FirstName = user.FirstName, LastName = user.LastName };
            return View(model);
        }
        public async Task<IActionResult> JoinInvitation(string token, string email)
        {
            var user = await _userManager.Users.Include(u => u.Company).FirstOrDefaultAsync(u => u.Email.ToUpper() == email.ToUpper());
            return View(new JoinInvitationViewModel { Token = token, Email = email, FirstName = user.FirstName, LastName = user.LastName, CompanyName = user.Company.Name });
        }

        [HttpPost]
        public async Task<IActionResult> JoinInvitation(JoinInvitationViewModel model)
        {
            //var user = await _userManager.FindByEmailAsync(model.Email);
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return RedirectToAction("UserJoin", "Account");
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.EmailConfirmed = true;
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                TempData["IsValid"] = true;
            }
            else if (result.Errors.Any(e => e.Code != "InvalidToken"))
            {
                foreach (var error in result.Errors.Where(e => e.Code != "InvalidToken"))
                {
                    ViewBag.ShowAlert += error.Description + Environment.NewLine;
                    return View(model);
                }
            }
            return RedirectToAction("UserJoin", "Account");
        }

        [HttpGet]
        public IActionResult UserJoin()
        {
            return View(model: TempData["IsValid"] ?? false);
        }

        [HttpPost]

        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                RedirectToAction("ResetPassword");
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ViewBag.ShowAlert += error.Description + Environment.NewLine;
                return View();
            }


            return RedirectToAction("Login", "Account");


        }
    }
}
