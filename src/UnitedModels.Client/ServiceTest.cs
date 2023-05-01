using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using PersonServiceHttp = UnitedModels.Http.PersonService;
using PersonServiceGrpc = UnitedModels.Grpc.PersonService;
using PersonMapServiceGrpc = UnitedModels.Map.Grpc.PersonService;

namespace UnitedModels.Client
{
    public class ServiceTest
    {
        private readonly long[] _ids;

        private readonly PersonServiceHttp _serviceHttp;
        private readonly PersonServiceGrpc _serviceGrpc;
        private readonly PersonMapServiceGrpc _serviceMapGrpc;

        public ServiceTest()
        {
            _ids = new long[] { 1, 2, 3, 4 };
            
            _serviceHttp = new PersonServiceHttp("http://localhost:8277");
            _serviceGrpc = new PersonServiceGrpc("http://localhost:8278");
            _serviceMapGrpc = new PersonMapServiceGrpc("http://localhost:8378");
        }

        [Benchmark]
        public async Task TestHttp()
        {
            foreach (var id in _ids)
            {
                await _serviceHttp.GetAsync(id, CancellationToken.None);
            }
        }
        
        [Benchmark]
        public async Task TestGrpc()
        {
            foreach (var id in _ids)
            {
                await _serviceGrpc.GetAsync(id, CancellationToken.None);
            }
        }
        
        [Benchmark]
        public async Task TestMapGrpc()
        {
            foreach (var id in _ids)
            {
                await _serviceMapGrpc.GetAsync(id, CancellationToken.None);
            }
        }
    }
}