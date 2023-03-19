using System.ComponentModel.DataAnnotations;

namespace dataStorage.Models.Entities
{
    internal class ErrandEntity 
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime ErrandTimeCreated { get; set; }
        public string CustomerDescription { get; set; } = null!;


        public Guid CustomerId { get; set; }
        public CustomerEntity Customer { get; set; } = null!;


        public Guid ErrandStatusId { get; set; }
        public ErrandStatusEntity ErrandStatus { get; set; } = null!;
    }
}
