using System.Threading;
using System.Threading.Tasks;
using UnitedModels.Models;

namespace UnitedModels
{
    public interface IPersonService
    {
        Task<IPerson> GetAsync(long id, CancellationToken cancellationToken);
    }
}