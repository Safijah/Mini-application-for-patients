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
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registration(ResultVM result)
        {
            TempData["Message"] = result.Message;
            return View();
        }
        public async Task<IActionResult> RegisterAsync(RegisterVM register)
        {
            try
            {
                var rezultat= await _userService.RegistracijaAsync(register);
                if(rezultat.IsSuccess)
                {

                return View("Home");
                }
                else
                {
                    return RedirectToAction("Registration",rezultat);
                }
            }
            catch (Exception ex)
            {
                var rezultat = new ResultVM()
                {
                    Message = ex.Message
                };

                return RedirectToAction("Registration", rezultat);
            }
            return View();
        }
        public IActionResult Login(ResultVM result)
        {
            TempData["Message"] = result.Message;
            return View();
        }
        public async Task<IActionResult> LoginUserAsync(LoginVM login)
        {
            try
            {
                var rezultat = await _userService.LoginUserAsync(login);
                if (rezultat.IsSuccess)
                {

                    return View("Home");
                }
                else
                {
                    return RedirectToAction("Login", rezultat);
                }
            }
            catch (Exception ex)
            {
                var rezultat = new ResultVM()
                {
                    Message = ex.Message
                };

                return RedirectToAction("Login", rezultat);
            }
            return View();
        }
    }
}
