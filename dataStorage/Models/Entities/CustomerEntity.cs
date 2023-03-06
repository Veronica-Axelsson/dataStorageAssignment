using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace dataStorage.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]

    internal class CustomerEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [StringLength(100)]
        public string Email { get; set; } = null!;


        //public int PhoneNumberId { get; set; }
        public PhoneEntity PhoneNr { get; set; } = null!;


        //public ICollection<ErrandEntity> Errands = new HashSet<ErrandEntity>();
    }
}
