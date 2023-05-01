using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using PersonGrpcService = UnitedModels.Protos.PersonService.PersonServiceBase;

namespace UnitedModels.Protos.Services
{
    public class PersonService : PersonGrpcService
    {
        private readonly Dictionary<long, Models.Person> _data;

        private readonly Models.Person _defaultPerson;

        public PersonService()
        {
            _data = new List<Models.Person>
            {
                new Models.Person
                {
                    Id = 1,
                    Name = "Person #1",
                    Timestamp = new DateTime(2023, 4,30, 12, 9, 0, DateTimeKind.Utc),
                    Address = {
                        Id = 1,
                        Data = "Almaty, Kazakhstan",
                        LineIndex = 23
                    }
                },
                new Models.Person
                {
                    Id = 2,
                    Name = "Person #2",
                    Timestamp = new DateTime(2023, 4,30, 12, 12, 0, DateTimeKind.Utc),
                    Address = {
                        Id = 2,
                        Data = "Astana, Kazakhstan",
                        LineIndex = 13
                    }
                },
                new Models.Person
                {
                    Id = 3,
                    Name = "Person #3",
                    Timestamp = new DateTime(2023, 4,30, 12, 13, 0, DateTimeKind.Utc),
                    Address = {
                        Id = 3,
                        Data = "Shymkent, Kazakhstan",
                        LineIndex = 3
                    }
                }
            }.ToDictionary(item => item.Id);

            _defaultPerson = new Models.Person
            {
                Id = 4,
                Name = "Person #4",
                Timestamp = new DateTime(2023, 4, 30, 12, 14, 0, DateTimeKind.Utc),
                Address =
                {
                    Id = 4,
                    Data = "Kazygurt, Kazakhstan"
                }
            };
        }

        public override Task<Person> Get(GetRequest request, ServerCallContext context)
        {
            return Task.FromResult(
                _data.TryGetValue(request.Id, out var value)
                ? value.Message
                : _defaultPerson.Message);
        }
    }
}