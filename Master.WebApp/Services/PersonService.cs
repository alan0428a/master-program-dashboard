using Master.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Master.Domain;

namespace Master.WebApp.Services
{
    public class PersonService : IPersonService
    {
        private readonly MasterContext _context;
        public PersonService(MasterContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(int id)
        {
            var data = await _context.Persons.FirstOrDefaultAsync(x => x.Id == id);
            if (data is not null)
            {
                _context.Persons.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _context.Persons.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> SaveAsync(Person data)
        {
            
            if (data.Id == 0)
            {
                if (_context.Persons.Contains(data))
                {
                    throw new DbUpdateException($"Same program already existed");
                }
                _context.Persons.Add(data);
            }
            else
            {
                _context.Persons.Update(data);
            }
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
