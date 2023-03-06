using System.ComponentModel.DataAnnotations;

namespace dataStorage.Models.Entities
{
    internal class ErrandEntity 
    {
        [Key]
        public int ErrandId { get; set; }

        public DateTime ErrandTimeCreated { get; set; }
        public string CustomerDescription { get; set; } = null!;
        public DateTime TimeEmployeeComment { get; set; }
        public string EmployeeComment { get; set; } = null!;


        //public int ErrandsStatusId { get; set; }
        public ErrandEntity ErrandStatus { get; set; } = null!;


        //public int CustomersId { get; set; }
        public CustomerEntity Customer { get; set; } = null!;
    }
}
