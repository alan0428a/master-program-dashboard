using Master.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Master.Domain;

namespace Master.WebApp.Services
{
    public class AdmissionService : IAdmissionService
    {
        private readonly MasterContext _context;
        public AdmissionService(MasterContext context)
        {
            _context = context;
        }

        public async Task<List<Admission>> GetByPersonIdAsync(int id)
        {
            return await _context.Admissions.Where(x => x.PersonId == id).ToListAsync();
        }

        public async Task DeleteByPersonIdAsync(int id)
        {
            var oldAdmissions = await _context.Admissions.Where(x => x.PersonId == id).ToArrayAsync();
            _context.Admissions.RemoveRange(oldAdmissions);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Admission>> GetAllAsync()
        {
            return await _context.Admissions.ToListAsync();
        }

        public async Task SaveAsync(List<Admission> data)
        {
            if(data.Count != 0)
            {
                await DeleteByPersonIdAsync(data.First().PersonId);
                
                _context.Admissions.AddRange(data);
                await _context.SaveChangesAsync();
            }
        }


    }
}
