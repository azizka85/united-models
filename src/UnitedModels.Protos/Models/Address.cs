using UnitedModels.Models;

namespace UnitedModels.Protos.Models
{
    public sealed class Address : IAddress
    {
        private readonly Protos.Address _address;

        public Address(Protos.Address address = null)
        {
            _address = address ?? new Protos.Address();
        }

        public Protos.Address Message => _address;

        public long Id
        {
            get => _address.Id;
            set => _address.Id = value;
        }

        public string Data
        {
            get => _address.Data;
            set => _address.Data = value;
        }

        public int? LineIndex
        {
            get => _address.HasLineIndex ? _address.LineIndex : null;
            set
            {
                if (value.HasValue)
                {
                    _address.LineIndex = value.Value;
                }
                else
                {
                    _address.ClearLineIndex();
                }
            }
        }
    }
}