using Intranet.Persistance.Contracts;
using Intranet.Persistance.Models;
using Microsoft.EntityFrameworkCore;

namespace Intranet.Persistance.Services
{
    internal class InterestRepository : IRepository<Interest>
    {
        private readonly ApplicationDbContext _context;
        public InterestRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Interest> Create(Interest model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task DeleteById(int id)
        {
            var item = await _context.Interests.SingleOrDefaultAsync(x => x.Id == id);
            _context.Interests.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Interest>> Get()
        {
            var result = await _context.Interests.ToListAsync();
            return result;
        }

        public Task<Interest> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Interest> Update(Interest model)
        {
            throw new NotImplementedException();
        }
    }
}
