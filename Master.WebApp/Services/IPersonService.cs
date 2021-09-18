using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Master.Domain;

namespace Master.WebApp.Services
{
    public interface IPersonService
    {
        Task<List<Person>> GetAllAsync();
        Task<Person> GetByIdAsync(int id);
        Task<Person> SaveAsync(Person person);
        Task DeleteAsync(int id);
    }
}
