using Master.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Master.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Master.WebApp.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly MasterContext _context;
        public SchoolService(MasterContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(int id)
        {
            var school = await _context.Schools.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if(school is not null)
            {
                _context.Schools.Remove(school);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<School> GetByIdAsync(int id)
        {
            return await _context.Schools.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<School>> GetAllAsync()
        {
            return await _context.Schools.AsNoTracking().ToListAsync();
        }

        public async Task SaveAsync(School school)
        {
            if(school.Id == 0)
            {
                if (_context.Schools.Contains(school))
                {
                    throw new DbUpdateException($"Same school already existed");
                }
                _context.Schools.Add(school);
            }
            else
            {
                _context.Schools.Update(school);
            }
            await _context.SaveChangesAsync();
        }
    }
}
