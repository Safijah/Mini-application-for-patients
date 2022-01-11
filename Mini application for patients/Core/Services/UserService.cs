using Core.Interfaces;
using Data.DbContext;
using Data.EntityModels;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private UserManager<User> _userManger;
        private IConfiguration _configuration;
        private AppDbContext _appDbContext;
        private RoleManager<IdentityRole> _roleManager;
        public UserService(UserManager<User> userManager, IConfiguration configuration, AppDbContext appDbContext, 
            RoleManager<IdentityRole> roleManager)
        {
            _userManger = userManager;
            _configuration = configuration;
            _appDbContext = appDbContext;
            _roleManager = roleManager;
        }
        public async Task<ResultVM> RegistracijaAsync(RegisterVM model)
        {
            if (model == null)
                throw new NullReferenceException("You need to insert data");
            var postojeci = await _userManger.FindByEmailAsync(model.Email);
            if (postojeci != null)
            {
                return new ResultVM
                {
                    Message = "The user already exists in the database with this email.",
                    IsSuccess = false,
                };
            }
            if (model.Password != model.ConfirmedPassword)
                return new ResultVM
                {
                    Message = "Passwords do not match",
                    IsSuccess = false,
                };

            var identityUser = new User
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            var role = await _roleManager.FindByIdAsync("2");

            var result = await _userManger.CreateAsync(identityUser, model.Password);

            if (result.Succeeded)
            {
                var roleResult = await _userManger.AddToRoleAsync(identityUser, role.Name);
                if (!roleResult.Succeeded)
                    return new ResultVM
                    {
                        Message = "User already exists",
                        IsSuccess = false,
                        Errors = result.Errors.Select(e => e.Description)
                    };
                var Patient = new Patient()
                {
                    User = identityUser
                };
                _appDbContext.Add(Patient);
                _appDbContext.SaveChanges();

                return new ResultVM
                {
                    Message = "User successfully created ",
                    IsSuccess = true,
                };
            }

            return new ResultVM
            {
                Message = "User not created",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }
        public async Task<ResultVM> LoginUserAsync(LoginVM model)
        {
            var user = await _userManger.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return new ResultVM
                {
                    Message = "Invalid email or password",
                    IsSuccess = false,
                };
            }

            var result = await _userManger.CheckPasswordAsync(user, model.Password);

            if (!result)
                return new ResultVM
                {
                    Message = "Invalid email or password",
                    IsSuccess = false,
                };

            var claims = new[]
            {
                new Claim("Email", model.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new ResultVM
            {
                Message = tokenAsString,
                IsSuccess = true,
                ExpireDate = token.ValidTo
            };
        }
    }
}
