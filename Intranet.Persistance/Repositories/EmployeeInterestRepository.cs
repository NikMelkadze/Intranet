using Intranet.Persistance.Contracts;
using Intranet.Persistance.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Persistance.Repositories
{
    public class EmployeeInterestRepository : IRepository<EmployeeInterest>
    {
        private readonly ApplicationDbContext _context;
        public EmployeeInterestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeInterest> Create(EmployeeInterest model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmployeeInterest>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeInterest> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmployeeInterest>> GetByUser(int id)
        {
            var employeeInterest = await _context.EmployeeInterest.Include(y => y.Interest).Include(x => x.Employee).Where(x => x.EmployeeId == id).ToListAsync();
            return employeeInterest;
        }

        public Task<EmployeeInterest> Update(EmployeeInterest model)
        {
            throw new NotImplementedException();
        }
    }
}
