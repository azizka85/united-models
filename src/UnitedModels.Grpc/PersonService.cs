using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Net.Client;
using UnitedModels.Models;

namespace UnitedModels.Grpc
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

            return new Protos.Models.Person(
                await _client.GetAsync(request, cancellationToken: cancellationToken));
        }
    }
}