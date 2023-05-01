namespace UnitedModels.Models
{
    public interface IAddress
    {
        long Id { get; set; }
        
        string Data { get; set; }
        
        int? LineIndex { get; set; }
    }
}