using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IApiRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> Get();
    }
}