using System.Threading.Tasks;
using BenchmarkDotNet.Running;
using PersonServiceHttp = UnitedModels.Http.PersonService;
using PersonServiceGrpc = UnitedModels.Grpc.PersonService;

namespace UnitedModels.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            BenchmarkRunner.Run<ServiceTest>();
        }
    }
}