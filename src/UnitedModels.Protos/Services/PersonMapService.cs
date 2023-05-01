using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using PersonGrpcService = UnitedModels.Protos.PersonService.PersonServiceBase;

namespace UnitedModels.Protos.Services
{
    public class PersonMapService : PersonGrpcService
    {
        private readonly Dictionary<long, UnitedModels.Models.Data.Person> _data;

        private readonly UnitedModels.Models.Data.Person _defaultPerson;

        public PersonMapService()
        {
            _data = new List<UnitedModels.Models.Data.Person>
            {
                new UnitedModels.Models.Data.Person
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
                new UnitedModels.Models.Data.Person
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
                new UnitedModels.Models.Data.Person
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

            _defaultPerson = new UnitedModels.Models.Data.Person
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
                    ? GetResponse(value)
                    : GetResponse(_defaultPerson));
        }

        private Person GetResponse(UnitedModels.Models.Data.Person person)
        {
            var response = new Person
            {
                Id = person.Id,
                Name = person.Name,
                Timestamp = person.Timestamp.HasValue ? Timestamp.FromDateTime(person.Timestamp.Value) : null,
                Address = new Address
                {
                    Id = person.Address.Id,
                    Data = person.Address.Data
                }
            };

            if (person.Address.LineIndex.HasValue)
            {
                response.Address.LineIndex = person.Address.LineIndex.Value;
            }

            return response;
        }
    }
}