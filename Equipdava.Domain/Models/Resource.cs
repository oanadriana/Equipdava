namespace Equipdava.Domain.Models
{
    public class Resource
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int ResourceTypeId { get; set; }

        public bool IsAllocated { get; set; }
    }
}
