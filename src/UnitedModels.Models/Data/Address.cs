namespace UnitedModels.Models.Data
{
    public class Address : IAddress
    {
        public long Id { get; set; }
        
        public string Data { get; set; }
        
        public int? LineIndex { get; set; }
    }
}