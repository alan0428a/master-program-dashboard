using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Master.Domain;

namespace Master.WebApp.Services
{
    public interface ISchoolService
    {
        Task<List<School>> GetAllAsync();
        Task<School> GetByIdAsync(int id);
        Task SaveAsync(School school);
        Task DeleteAsync(int id);
    }
}
