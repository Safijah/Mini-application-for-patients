using Core.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_application_for_patients.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        static string Message;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registration()
        {
            TempData["Message"] = Message;
            Message = null;
            return View();
        }
        public async Task<IActionResult> RegisterAsync(RegisterVM register)
        {
            try
            {
                var rezultat= await _userService.RegistracijaAsync(register);
                if(rezultat.IsSuccess)
                {

                    var rola = await _userService.CheckUser(register.Email);
                    if (rola == "Admin")
                    {

                        return Redirect("/Admin/Appointments");
                    }
                    else
                    {
                        return Redirect("/Patient/Appointments?Email=" + register.Email);
                    }
                }
                else
                {
                    Message = rezultat.Message;
                    return RedirectToAction("Registration");
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;

                return RedirectToAction("Registration");
            }
           
        }
        public IActionResult Login()
        {
            TempData["Message"] = Message;
            Message = null;
            return View();
        }
        public async Task<IActionResult> LoginUserAsync(LoginVM login)
        {
            try
            {
                var rezultat = await _userService.LoginUserAsync(login);
                if (rezultat.IsSuccess)
                {
                    var rola = await _userService.CheckUser(login.Email);
                    if(rola=="Admin")
                    {

                    return Redirect("/Admin/Appointments");
                    }
                    else
                    {
                        return Redirect("/Patient/Appointments?Email="+login.Email);
                    }
                }
                else
                {
                    Message = rezultat.Message;
                    return RedirectToAction("Login");
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;

                return RedirectToAction("Login");
            }
            
        }
    }
}
