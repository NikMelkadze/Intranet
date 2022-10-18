using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Persistance.Contracts
{
    public interface IRepository<T>
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> Get();
        Task<T> Update(T model);
        Task DeleteById(int id);
        Task<T> Create(T model);
        Task<IEnumerable<T>> GetByUser(int id);
    }
}
