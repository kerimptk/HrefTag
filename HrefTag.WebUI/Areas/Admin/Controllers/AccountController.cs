using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BaseCore.Aspects.MVC;
using BaseCore.Aspects.Validation;
using BaseCore.Controllers.MVC;
using BaseCore.Utilities.Enum;
using BaseCore.Utilities.Helpers;
using Blog.Domain.DataTransferObjects;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Domain.Security.Hashing;
using Blog.Domain.Validations.FluentValidation;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HrefTag.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public AccountController(IUserRoleRepository userRoleRepository, IPasswordHasher passwordHasher, IConfiguration configuration, IUserRepository userRepository, IUserService userService, IAuthService authService, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(httpContextAccessor)
        {
            _userRoleRepository = userRoleRepository;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
            _userService = userService;
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("Login")]
        public IActionResult Login()
        {
            if (HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Dashboard", "Home");

            return View();
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var login = _authService.Login(loginDto);
            //oPNWVJ%vKnff

            if (!login.Success)
            {
                Alert("Hata", login.Message, SweetAlertNotificationType.error);
                return View(loginDto);
            }

            var result = _authService.CreateAccessToken(login.Data);

            if (result.Success)
            {
                HttpContext.Session.SetString("JWToken", result.Data.Token);
                HttpContext.Request.Headers.Add("Authorization", "Bearer" + result.Data.Token);
                return RedirectToAction("Dashboard", "Home", new { area = "Admin" });
            }
            Alert("Hata", "Bir hata oluştu", SweetAlertNotificationType.error);
            return View(loginDto);
        }


        [Route("Home")]
        [HttpGet("Logout")]
        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("ProfilBilgileri")]
        [Authorize]
        public IActionResult ProfilBilgileri()
        {
            var id = GetUserId();
            var user = _userService.GetById(id);
            var userMapper = _mapper.Map<ProfilDto>(user);
            return View(userMapper);
        }

        [HttpGet("KullaniciIslemleri")]
        [Authorize]
        public IActionResult KullaniciIslemleri()
        {
            var users = _userService.GetList();
            var usersMap = _mapper.Map<List<UserListDto>>(users);
            var viewModel = new AdminKullaniciViewModel()
            {
                userListDtos = usersMap
            };
            return View(viewModel);
        }


        [HttpGet("ProfilDuzenle")]
        [Authorize]
        public IActionResult ProfilDuzenle()
        {
            var id = GetUserId();
            var user = _userService.GetById(id);
            var userMap = _mapper.Map<ProfilDto>(user);
            var viewModel = new AdminKullaniciGuncelleViewModel()
            {
                profilDto = userMap
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ProfilDuzenleOnay(ProfilDto profilDto)
        {
            var user = _userService.GetById(profilDto.Id);
            user.Name = profilDto.Name;
            user.Surname = profilDto.Surname;
            user.Email = user.Email;
            user.About = profilDto.About;
            user.Adress = profilDto.Adress;
            user.Skills = profilDto.Skills;
            user.Education = profilDto.Education;
            user.Job = profilDto.Job;
            user.PasswordHash = user.PasswordHash;
            user.PasswordSalt = user.PasswordSalt;
            user.Status = user.Status;
            user.UserName = user.UserName;

            var files = HttpContext.Request.Form.Files;
            foreach (var file in files)
            {
                string fName = Guid.NewGuid().ToString() + file.FileName;
                if (file.Name == "ImagePath")
                    user.ImagePath = fName;

                string path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\", fName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            _userService.Update(user);

            return RedirectToAction("ProfilBilgileri", "Account");
        }

        [Authorize]
        public IActionResult PasswordReset(PasswordResetUserDto passwordResetUserDto)
        {
            _authService.ResetPassword(passwordResetUserDto);
            return RedirectToAction("KullaniciIslemleri", "Account");
        }

        [Authorize]
        public IActionResult aktifPasif([FromQuery(Name = "Id")] int id)
        {
            var user = _userService.GetById(id);
            if (user.Status == true)
            {
                user.Status = false;
            }
            else
            {
                user.Status = true;
            };
            _userService.Update(user);

            return RedirectToAction("KullaniciIslemleri", "Account");
        }

        [HttpPost("KullaniciEkle")]
        [Authorize]
        public IActionResult KullaniciEkle(RegisterDto registerDto)
        {
            _authService.Register(registerDto, registerDto.Password.ToString());

            return RedirectToAction("KullaniciIslemleri", "Account");
        }
    }
}
