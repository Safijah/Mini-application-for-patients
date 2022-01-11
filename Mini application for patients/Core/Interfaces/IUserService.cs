using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Core.Interfaces
{
    public interface IUserService
    {
        Task<ResultVM> RegistracijaAsync(RegisterVM model);
        Task<ResultVM> LoginUserAsync(LoginVM model);
    }
}
