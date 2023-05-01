using System.Threading;
using System.Threading.Tasks;
using Grpc.Net.Client;
using UnitedModels.Models;

namespace UnitedModels.Map.Grpc
{
    public class PersonService : IPersonService
    {
        private readonly Protos.PersonService.PersonServiceClient _client;
        
        public PersonService(string serviceUri)
        {
            var channel = GrpcChannel.ForAddress(serviceUri);

            _client = new Protos.PersonService.PersonServiceClient(channel);
        }
        
        public async Task<IPerson> GetAsync(long id, CancellationToken cancellationToken)
        {
            var request = new Protos.GetRequest
            {
                Id = id
            };

            var response = await _client.GetAsync(request, cancellationToken: cancellationToken);

            return new Models.Data.Person
            {
                Id = response.Id,
                Name = response.Name,
                Timestamp = response.Timestamp?.ToDateTime(),
                Address =
                {
                    Id = response.Address.Id,
                    Data = response.Address.Data,
                    LineIndex = response.Address.HasLineIndex ? response.Address.LineIndex : null
                }
            };
        }
    }
}