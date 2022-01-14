using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_application_for_patients.Models;

namespace Mini_application_for_patients.Controllers
{
    public class PatientController : Controller
    {
        private IUserService _userService;
        public PatientController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AppointmentsAsync(string Email)
        {
            var List = await _userService.DisplayAppointmentsByIDAsync(Email);
            var lista = new List<GetAppointmentVM.Lista>();
            foreach (var x in List.Appointment)
            {
                var appointment = new GetAppointmentVM.Lista
                {
                    Date = x.Date,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ID = x.ID
                };
                lista.Add(appointment);
            }
            var vm = new GetAppointmentVM();
            vm.Appointment = lista;
            return View(vm);
        }
    }
}
