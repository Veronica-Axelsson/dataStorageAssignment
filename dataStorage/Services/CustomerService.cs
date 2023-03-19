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
            };

            var _customerEntity = await _context.Customers.FirstOrDefaultAsync(x => x.FirstName == errand.FirstName && x.LastName == errand.LastName && x.Email == errand.Email && x.CustomerPhoneNr == errand.CustomerPhoneNr);

            if (_customerEntity != null)
                _errandEntity.Customer.Id = _customerEntity.Id;
            else
                _errandEntity.Customer = new CustomerEntity
                {
                    FirstName = errand.FirstName,
                    LastName = errand.LastName,
                    Email = errand.Email,
                    CustomerPhoneNr = errand.CustomerPhoneNr
                };

            var _statusEntity = await _context.ErrandStatus.FirstOrDefaultAsync(x => x.Status == errand.Status);

            if (_statusEntity != null)
                _errandEntity.ErrandStatus.Id = _statusEntity.Id;
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

            foreach (var _errand in await _context.Errands.Include(x => x.Customer).Include(x => x.ErrandStatus).ToListAsync())
                _errands.Add(new Errands
                {
                    Id = _errand.Id,
                    FirstName = _errand.Customer.FirstName,
                    LastName = _errand.Customer.LastName,
                    Email = _errand.Customer.Email,
                    CustomerPhoneNr = _errand.Customer.CustomerPhoneNr,
                    ErrandTimeCreated = _errand.ErrandTimeCreated,
                    CustomerDescription = _errand.CustomerDescription,
                    Status = _errand.ErrandStatus.Status, 
                });

            return _errands;
        }


        public static async Task<Errands> GetAsync(Guid newGuid)
        {
            var _errand = await _context.Errands.Include(x => x.Customer).Include(x => x.ErrandStatus).FirstOrDefaultAsync(x => x.Id == newGuid);

            if (_errand != null)
                return new Errands
                {
                    Id = _errand.Id,
                    FirstName = _errand.Customer.FirstName,
                    LastName = _errand.Customer.LastName,
                    Email = _errand.Customer.Email,
                    CustomerPhoneNr = _errand.Customer.CustomerPhoneNr,
                    ErrandTimeCreated = _errand.ErrandTimeCreated,
                    CustomerDescription = _errand.CustomerDescription,
                    Status = _errand.ErrandStatus.Status,
                };
            else
                return null!;
        }


        public static async Task UpdateAsync(Errands errands)
        {
            var _errand = await _context.Errands.Include(x => x.ErrandStatus).FirstOrDefaultAsync(x => x.Id == errands.Id);

            if (_errand != null)
            {
                //Errand status -----------------------------------------
                if (!string.IsNullOrEmpty(errands.Status))
                {
                    _errand.ErrandStatus.Status = errands.Status;
                }

                _context.Update(_errand);
                await _context.SaveChangesAsync();
            }
        }

    }
}
