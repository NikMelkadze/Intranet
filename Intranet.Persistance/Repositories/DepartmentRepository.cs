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
    public class DepartmentRepository : IRepository<DepartmentDTO>
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DepartmentDTO> Create(DepartmentDTO model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task DeleteById(int id)
        {
            var item = await _context.Departments.SingleOrDefaultAsync(x => x.Id == id);
            _context.Departments.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DepartmentDTO>> Get()
        {
            var result = await _context.Departments.ToListAsync();
            return result;
        }

        public Task<DepartmentDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DepartmentDTO>> GetByUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentDTO> Update(DepartmentDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
