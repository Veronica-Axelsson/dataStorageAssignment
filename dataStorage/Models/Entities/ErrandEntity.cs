namespace dataStorage.Models.Entities
{
    internal class ErrandEntity 
    {
        public int Id { get; set; }

        public DateTime ErrandTimeCreated { get; set; }     
        public string CustomerDescription { get; set; } = null!;
        public DateTime TimeEmployeeComment { get; set; }
        public string EmployeeComment { get; set; } = null!;


        public int ErrandStatusId { get; set; }
        public ErrandEntity ErrandStatus { get; set; } = null!;


        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; } = null!;
    }
}
