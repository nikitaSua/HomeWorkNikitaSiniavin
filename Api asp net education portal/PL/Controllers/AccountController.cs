using AutoMapper;
using BLL;
using BLL.DtoModels;
using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PL.ServicesExtensions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private IUserService userService;
        private IAccountService accountService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, IAccountService accountService)
        {
            this.userService = userService;
            this.accountService = accountService;
            var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile(new MapperProfile()));
            _mapper = new Mapper(mapperConfiguration);
        }

        [HttpPost("Login")]
        public IActionResult Login(string Email, string password)
        {
            var identity = GetIdentity(Email, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid Email or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            
            return Json(response);
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterModel model)
        {
            if (model!=null&& ModelState.IsValid)
            {
                var searchExistUsers = userService.GetUser(u => u.Email == model.Email||u.Login==model.Login);
                if (searchExistUsers==null)
                {
                    UserModel user = _mapper.Map<UserModel>(model);

                    accountService.AddUser(user);

                    var identity = GetIdentity(model.Email, model.Password);
                    if (identity == null)
                    {
                        return BadRequest(new { errorText = "Invalid Email or password." });
                    }
                    var now = DateTime.UtcNow;
                    // создаем JWT-токен
                    var jwt = new JwtSecurityToken(
                            issuer: AuthOptions.ISSUER,
                            audience: AuthOptions.AUDIENCE,
                            notBefore: now,
                            claims: identity.Claims,
                            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                    var response = new
                    {
                        access_token = encodedJwt,
                        username = identity.Name
                    };
                    return Json(response);
                }
            }
            return BadRequest(new { errorText = "Invalid Email or password." });
        }

        private ClaimsIdentity GetIdentity(string Email, string password)
        {

            UserModel person = userService.GetUser(x => x.Email == Email && x.Password == password);

            if (person != null)
            {
                
                var claims = new List<Claim>
                {

                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, userService.GetUserRole(person))
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }
    }
}
