using System;
using System.Threading;
using Flurl;
using System.Threading.Tasks;
using Flurl.Http;
using UnitedModels.Models;
using UnitedModels.Models.Data;

namespace UnitedModels.Http
{
    public class PersonService : IPersonService
    {
        private readonly string _serviceUri;
        
        public PersonService(string serviceUri)
        {
            _serviceUri = serviceUri ?? throw new ArgumentNullException(nameof(serviceUri));
        }
        
        public async Task<IPerson> GetAsync(long id, CancellationToken cancellationToken)
        {
            return await _serviceUri
                .AppendPathSegment("person")
                .AppendPathSegment(id)
                .GetJsonAsync<Person>(cancellationToken);
        }
    }
}