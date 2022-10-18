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
    public class EmployeeRepository : IRepository<ApplicationUserDTO>
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ApplicationUserDTO> Create(ApplicationUserDTO model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ApplicationUserDTO>> Get()
        {
            var employees = await _context.Users.Include(x => x.Department).ToListAsync();
            return employees;
        }

        public async Task<ApplicationUserDTO> GetById(int id)
        {
            var employee = await _context.Users.Include(y=>y.Department).SingleOrDefaultAsync(x => x.UserId == id);
            return employee;
        }

        public Task<IEnumerable<ApplicationUserDTO>> GetByUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUserDTO> Update(ApplicationUserDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
