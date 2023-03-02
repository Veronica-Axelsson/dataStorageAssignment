using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataStorage.Models.Entities
{
    internal class PhoneEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string CustomerPhoneNr { get; set; } = null!;


        public ICollection<CustomerEntity> Customers = new HashSet<CustomerEntity>();
    }
}
