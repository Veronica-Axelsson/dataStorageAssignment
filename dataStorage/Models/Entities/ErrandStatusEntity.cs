using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dataStorage.Models.Entities
{
    internal class ErrandStatusEntity
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Status { get; set; } = null!;


        public ICollection<ErrandEntity> Errands = new HashSet<ErrandEntity>();
    }
}
