using System;

namespace UnitedModels.Models.Data
{
    public class Person : IPerson
    {
        public Person(Address address = null)
        {
            Address = address ?? new Address();
        }

        public long Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime? Timestamp { get; set; }
        
        public IAddress Address { get; }
    }
}