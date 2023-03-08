using dataStorage.Contexts;
using dataStorage.Models;
using dataStorage.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace dataStorage.Services
{
    internal class CustomerService
    {
        private static DataContext _context = new DataContext();

        public static async Task SaveAsync(Errands errand)
        {
            var _errandEntity = new ErrandEntity
            {
                ErrandTimeCreated = errand.ErrandTimeCreated,
                CustomerDescription = errand.CustomerDescription,
                TimeEmployeeComment = errand.TimeEmployeeComment,
                EmployeeComment = errand.EmployeeComment
            };

            //var _customerEntity = new CustomerEntity
            //{
            //    FirstName = errand.FirstName,
            //    LastName = errand.LastName,
            //    Email = errand.Email,
            //};

            //var _statusEntity = new ErrandStatusEntity
            //{
            //    Status = errand.Status
            //};

            //var _phoneEntity = new PhoneEntity
            //{
            //    CustomerPhoneNr = errand.CustomerPhoneNr
            //};

            var _customerEntity = await _context.Customers.FirstOrDefaultAsync(x => x.FirstName == errand.FirstName && x.LastName == errand.LastName && x.Email == errand.Email);
            var _phoneEntity = await _context.PhoneNumber.FirstOrDefaultAsync(x => x.CustomerPhoneNr == errand.CustomerPhoneNr);
            var _statusEntity = await _context.ErrandStatus.FirstOrDefaultAsync(x => x.Status == errand.Status);


            if (_customerEntity != null)
                _errandEntity.Customer.Id = _customerEntity.Id;
            else
                _errandEntity.Customer = new CustomerEntity
                {
                    FirstName = errand.FirstName,
                    LastName = errand.LastName,
                    Email = errand.Email,
                };

            if (_phoneEntity != null)
                _errandEntity.Customer.Id = _phoneEntity.Id;
            else
                _errandEntity.PhoneNr = new PhoneEntity
                {
                    CustomerPhoneNr = errand.CustomerPhoneNr
                };

            if (_statusEntity != null)
                _errandEntity.Customer.Id = _statusEntity.Id;
            else
                _errandEntity.ErrandStatus = new ErrandStatusEntity
                {
                    Status = errand.Status
                };


            _context.Add(_errandEntity);
            await _context.SaveChangesAsync();
        }


        public static async Task<IEnumerable<Errands>> GetAllAsync()
        {
            var _errands = new List<Errands>();

            foreach (var _errand in await _context.Errands.Include(x => x.Customer).ToListAsync())
                _errands.Add(new Errands
                {
                    Id = _errand.Id,
                    FirstName = _errand.Customer.FirstName,
                    LastName = _errand.Customer.LastName,
                    Email = _errand.Customer.Email,
                    //CustomerPhoneNr = _errand.PhoneNr,
                    ErrandTimeCreated = _errand.ErrandTimeCreated,
                    CustomerDescription = _errand.CustomerDescription,
                    //Status = _errand.ErrandStatus,
                    TimeEmployeeComment = _errand.TimeEmployeeComment,
                    EmployeeComment = _errand.EmployeeComment   
                });

            return _errands;
        }


        public static async Task<Errands> GetAsync(string email)
        {
            var _errand = await _context.Errands.Include(x => x.Customer.Email).FirstOrDefaultAsync(x => x.Customer.Email == email);

            if (_errand != null)
                return new Errands
                {
                    Id = _errand.Id,
                    FirstName = _errand.Customer.FirstName,
                    LastName = _errand.Customer.LastName,
                    Email = _errand.Customer.Email,
                    //CustomerPhoneNr = _errand.PhoneNr,
                    ErrandTimeCreated = _errand.ErrandTimeCreated,
                    CustomerDescription = _errand.CustomerDescription,
                    //Status = _errand.ErrandStatus,
                    TimeEmployeeComment = _errand.TimeEmployeeComment,
                    EmployeeComment = _errand.EmployeeComment
                };
            else
                return null!;
        }


        public static async Task UpdateAsync(Errands errands)
        {
            var _errandsEntity = await _context.Errands.Include(x => x.Id).FirstOrDefaultAsync(x => x.Id == errands.Id);

            if (_errandsEntity != null)
            {
                //Errand status -----------------------------------------
                if (!string.IsNullOrEmpty(errands.Status))
                    _errandsEntity.ErrandStatus = errands.Status;

      
                _context.Update(_errandsEntity);
                await _context.SaveChangesAsync();
            }
        }


        //public static async Task DeleteAsync(string email)
        //{
        //    var customer = await _context.Customers.Include(x => x.Address).FirstOrDefaultAsync(x => x.Email == email);

        //    if (customer != null)
        //    {
        //        _context.Remove(customer);
        //        await _context.SaveChangesAsync();
        //    }
        //}
    }
}
