using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.WebApp.Services
{
    public interface IProgramService
    {
        Task<List<Domain.Program>> GetAllAsync();
        Task<Domain.Program> GetByIdAsync(int id);
        Task SaveAsync(Domain.Program program);
        Task DeleteAsync(int id);
    }
}
