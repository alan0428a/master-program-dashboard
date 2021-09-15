using Master.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.WebApp.Services
{
    public class ProgramService : IProgramService
    {
        private readonly MasterContext _context;
        public ProgramService(MasterContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(int id)
        {
            var data = await _context.Programs.FirstOrDefaultAsync(x => x.Id == id);
            if (data is not null)
            {
                _context.Programs.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Domain.Program> GetByIdAsync(int id)
        {
            return await _context.Programs.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Domain.Program>> GetAllAsync()
        {
            return await _context.Programs.ToListAsync();
        }

        public async Task SaveAsync(Domain.Program data)
        {
            
            if (data.Id == 0)
            {
                if (_context.Programs.Contains(data))
                {
                    throw new DbUpdateException($"Same program already existed");
                }
                _context.Programs.Add(data);
            }
            else
            {
                _context.Programs.Update(data);
            }
            await _context.SaveChangesAsync();
        }
    }
}
