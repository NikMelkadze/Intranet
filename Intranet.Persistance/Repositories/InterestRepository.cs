using Intranet.Persistance.Contracts;
using Intranet.Persistance.Models;
using Microsoft.EntityFrameworkCore;

namespace Intranet.Persistance.Services
{
    internal class InterestRepository : IRepository<InterestDTO>
    {
        private readonly ApplicationDbContext _context;
        public InterestRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<InterestDTO> Create(InterestDTO model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public Task Delete(InterestDTO model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteById(int id)
        {
            var item = await _context.Interests.SingleOrDefaultAsync(x => x.Id == id);
            _context.Interests.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<InterestDTO>> Get()
        {
            var result = await _context.Interests.ToListAsync();
            return result;
        }

        public Task<InterestDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InterestDTO>> GetByUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<InterestDTO> Update(InterestDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
