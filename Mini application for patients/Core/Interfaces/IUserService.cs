using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.EntityModels;
using Data.Models;

namespace Core.Interfaces
{
    public interface IUserService
    {
        Task<ResultVM> RegistracijaAsync(RegisterVM model);
        Task<ResultVM> LoginUserAsync(LoginVM model);
        Task<GetAppointmentVM> DisplayAppointmentsAsync();
        Task<GetAppointmentVM> DisplayAppointmentsByIDAsync(string Email);
        Task<string> CheckUser(string Email);
        ResultVM AddAppointment(AddAppointmentVM appointment);
        Task<GetAppointmentVM> DisplayAppointmentsBySearchAsync(SearchVM vm);
    }
}
