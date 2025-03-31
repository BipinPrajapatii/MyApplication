using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApplication.Core;
using MyApplication.Data.Entities;
using MyApplication.Service;
using MyApplication.Service.Services;

namespace TimeTrackingSoft.Web.Controllers
{
    [Authorize(Roles = "SystemAdmin")]
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<User> _userManager;

        public CompaniesController(ICompanyService companyService, IMapper mapper, UserManager<User> userManager, IWebHostEnvironment environment, IEmailSender emailSender)
        {
            _companyService = companyService;
            _mapper = mapper;
            _userManager = userManager;
            _environment = environment;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            if (id <= 0)
            {
                return PartialView("/Views/Companies/_AddEdit.cshtml");
            }

            var model = await _companyService.Get(id);

            return PartialView("/Views/Companies/_AddEdit.cshtml", _mapper.Map<CompanyAddEditModel>(model));
        }                 
        

       
    }
}
