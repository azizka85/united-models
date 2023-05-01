using System;
using UnitedModels.Models;

namespace UnitedModels.Protos.Models
{
    public sealed class Person : IPerson
    {
        private readonly Protos.Person _person;

        public Person(Protos.Person person = null)
        {
            _person = person ?? new Protos.Person();

            if (_person.Address == null)
            {
                _person.Address = new Protos.Address();
            }
            
            Address = new Address(_person.Address);
        }

        public Protos.Person Message => _person;

        public long Id
        {
            get => _person.Id;
            set => _person.Id = value;
        }

        public string Name
        {
            get => _person.Name;
            set => _person.Name = value;
        }

        public DateTime? Timestamp
        {
            get => _person.Timestamp?.ToDateTime();
            set
            {
                if (value.HasValue)
                {
                    _person.Timestamp = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(value.Value);
                }
                else
                {
                    _person.Timestamp = null;
                }
            }
        }

        public IAddress Address { get; }
    }
}