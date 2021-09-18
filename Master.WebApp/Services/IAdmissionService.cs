using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Master.Domain;

namespace Master.WebApp.Services
{
    public interface IAdmissionService
    {
        Task<List<Admission>> GetAllAsync();
        Task<List<Admission>> GetByPersonIdAsync(int id);

        Task DeleteByPersonIdAsync(int id);
        Task SaveAsync(List<Admission> data);
    }
}
