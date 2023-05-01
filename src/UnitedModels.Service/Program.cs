using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace UnitedModels.Service
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            WebHost
                .CreateDefaultBuilder(args)
                .ConfigureKestrel((_, serverOptions) =>
                {
                    var endPointIndex = 0;
                    serverOptions.ConfigureEndpointDefaults(options =>
                    {
                        if (endPointIndex % 2 == 1)
                        {
                            options.Protocols = HttpProtocols.Http2;
                        }
                        else
                        {
                            options.Protocols = HttpProtocols.Http1AndHttp2;
                        }
                        
                        Console.WriteLine($"{endPointIndex} - {options.EndPoint} - {options.Protocols}");

                        endPointIndex++;
                    });
                })
                .UseStartup<Startup>()
                .Build()
                .Run();
        }
    }
}