using System.ComponentModel.DataAnnotations;

namespace dataStorage.Models.Entities
{
    internal class ErrandEntity 
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime ErrandTimeCreated { get; set; }
        public string CustomerDescription { get; set; } = null!;
        public DateTime TimeEmployeeComment { get; set; }
        public string EmployeeComment { get; set; } = null!;


        //public int ErrandsStatusId { get; set; }
        public ErrandStatusEntity ErrandStatus { get; set; } = null!;


        //public int CustomersId { get; set; }
        public CustomerEntity Customer { get; set; } = null!;


        //public int ErrandsStatusId { get; set; }

        //public int PhoneNrID2 { get; set; }
        public PhoneEntity PhoneNr { get; set; } = null!;
    }
}
