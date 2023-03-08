using dataStorage.Contexts;
using dataStorage.Models;
using dataStorage.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataStorage.Services
{
    internal class CustomerService
    {
        private static DataContext _context = new DataContext();

        public static async Task SaveAsync(Errands customer)
        {
            var _customerEntity = new CustomerEntity
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                //PhoneNumber = customer.CustomerPhoneNr,
            };

            var _addressEntity = await _context.Adresses.FirstOrDefaultAsync(x => x.StreetName == customer.StreetName && x.PostalCode == customer.PostalCode && x.City == customer.City);
            if (_addressEntity != null)
                _customerEntity.AddressId = _addressEntity.Id;
            else
                _customerEntity.Address = new AddressEntity
                {
                    StreetName = customer.StreetName,
                    PostalCode = customer.PostalCode,
                    City = customer.City
                };

            _context.Add(_customerEntity);
            await _context.SaveChangesAsync();
        }


        public static async Task<IEnumerable<Errands>> GetAllAsync()
        {
            var _errands = new List<Errands>();

            //foreach (var _errand in await _context.Errands.Include(x => x.Address).ToListAsync())
            //    _errands.Add(new Errands
            //    {
            //        Id = _errand.
            //        FirstName = _errand.F,
            //        LastName = _errands.LastName,
            //        Email = _errands.Email,
            //        PhoneNumber = _errands.PhoneNumber,
                
            //    });

            return _errands;
        }


        public static async Task<Errands> GetAsync(string email)
        {
            var _errands = await _context.Customers.Include(x => x.Address).FirstOrDefaultAsync(x => x.Email == email);

            if (_errands != null)
                return new Errands
                {
                    Id = _errands.Id,
                    FirstName = _errands.FirstName,
                    LastName = _errands.LastName,
                    Email = _errands.Email,
                    CustomerPhoneNr = _errands.CustomerPhoneNr
                };
            else
                return null!;
        }


        public static async Task UpdateAsync(Errands errands)
        {
            var _customerEntity = await _context.Customers.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == errands.Id);

            if (_customerEntity != null)
            {
                //Customer -----------------------------------------
                if (!string.IsNullOrEmpty(errands.FirstName))
                    _customerEntity.FirstName = errands.FirstName;

                if (!string.IsNullOrEmpty(errands.LastName))
                    _customerEntity.LastName = errands.LastName;

                if (!string.IsNullOrEmpty(errands.Email))
                    _customerEntity.Email = errands.Email;

                if (!string.IsNullOrEmpty(errands.CustomerPhoneNr))
                    _customerEntity.PhoneNumber = errands.CustomerPhoneNr;

                //// Adress ------------------------------------------
                //if (!string.IsNullOrEmpty(errands.StreetName) || !string.IsNullOrEmpty(errands.PostalCode) || !string.IsNullOrEmpty(customer.City))
                //{
                //    var _addressEntity = await _context.Adresses.FirstOrDefaultAsync(x => x.StreetName == errands.StreetName && x.PostalCode == errands.PostalCode && x.City == errands.City);
                //    if (_addressEntity != null)
                //        _customerEntity.AddressId = _addressEntity.Id;
                //    else
                //        _customerEntity.Address = new AddressEntity
                //        {
                //            StreetName = customer.StreetName,
                //            PostalCode = customer.PostalCode,
                //            City = customer.City
                //        };
                //}

                _context.Update(_customerEntity);
                await _context.SaveChangesAsync();
            }
        }


        public static async Task DeleteAsync(string email)
        {
            var customer = await _context.Customers.Include(x => x.Address).FirstOrDefaultAsync(x => x.Email == email);

            if (customer != null)
            {
                _context.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
