using Data.DbContext;
using Mini_application_for_patients.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Data.Models;

namespace Mini_application_for_patients.Controllers
{
    public class AdminController : Controller
    {
        private AppDbContext _appDbContext;
        private IUserService _userService;
        private static string Message;
        private static GetAppointmentVM Auxiliary=new GetAppointmentVM();
        public AdminController(AppDbContext appDbContext, IUserService userService)
        {
            _appDbContext = appDbContext;
            _userService = userService;
           
        }
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult AddAppointment()
        {
            List<SelectListItem> Patients = _appDbContext.Patient.Include(a=>a.User).Select(
                c => new SelectListItem
                {
                    Value=c.ID,
                    Text=c.User.FirstName+" "+c.User.LastName

                }).ToList();
            var vm = new AppointmentVM();
            vm.Patients = Patients;
            return View(vm);
        }
        public IActionResult SaveAppointment(AddAppointmentVM vm)
        {
            try
            {
                var result =  _userService.AddAppointment(vm);
                return Redirect("Appointments");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IActionResult> AppointmentsAsync()
        {
            if(Auxiliary.Note==null)
            {

                var List = await _userService.DisplayAppointmentsAsync();
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
                List<SelectListItem> Patients = _appDbContext.Patient.Include(a => a.User).Select(
                   c => new SelectListItem
                   {
                       Value = c.ID,
                       Text = c.User.FirstName + " " + c.User.LastName

                   }).ToList();
                var vm = new GetAppointmentVM();
                vm.Appointment = lista;
                vm.Patients = Patients;
                return View(vm);
            }
            else
            {
                List<SelectListItem> Patients = _appDbContext.Patient.Include(a => a.User).Select(
                   c => new SelectListItem
                   {
                       Value = c.ID,
                       Text = c.User.FirstName + " " + c.User.LastName

                   }).ToList();
                Auxiliary.Patients = Patients;
                Auxiliary.Note = null;
                return View(Auxiliary);
            }
        }
        public IActionResult AddPatient()
        {
            TempData["Message"] = Message;
            Message = null;
            return View();
        }
        public async Task<IActionResult> SavePatientAsync(Data.Models.RegisterVM register)
        {
            try
            {
                var rezultat = await _userService.RegistracijaAsync(register);
                if (rezultat.IsSuccess)
                {

                    return Redirect("Appointments");
                }
                else
                {
                    Message = rezultat.Message;
                    return RedirectToAction("AddPatient");
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;

                return RedirectToAction("AddPatient");
            }

        }
        public async Task<IActionResult> SearchAsync(GetAppointmentVM vm)
        {
            var search = new SearchVM()
            {
                PatientID = vm.PatientID,
                DateTo = vm.DateTo,
                DateFrom = vm.DateFrom
            };
            var appointmentVM = await _userService.DisplayAppointmentsBySearchAsync(search);
            var lista = new List<GetAppointmentVM.Lista>();
            foreach (var x in appointmentVM.Appointment)
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
            
            
            Auxiliary.Appointment = lista;
            Auxiliary.Note = "Note";
            return RedirectToAction("Appointments");
        }
    }
}
