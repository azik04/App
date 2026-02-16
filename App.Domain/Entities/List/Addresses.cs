using App.Domain.Entities.Main;

namespace App.Domain.Entities.List
{
    public class Addresses
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string? Address { get; set; }
        public Guid ClientId { get; set; }
        public List<Jobs> Job { get; set; }
    }
}
