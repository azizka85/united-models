using System;

namespace UnitedModels.Models
{
    public interface IPerson
    {
        long Id { get; set; }
        
        string Name { get; set; }
        
        DateTime? Timestamp { get; set; }
        
        IAddress Address { get; }
    }
}