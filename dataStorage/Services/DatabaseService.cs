using dataStorage.Models.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataStorage.Services
{
    internal class DatabaseService
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mille\Dropbox\EC-Utbildning\Datalagring\Assignment\dataStorageAssignment\dataStorage\Contexts\sql_database.mdf;Integrated Security=True;Connect Timeout=30";

        //public async Task SaveCustomerAsync(CustomerEntity customerEntity)
        //{
        
        //}


        //public async Task<int> GetOrSaveAddressAsync(AddressEntity addressEntity)
        //{
        
        //}


        //public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        //{
         
        //}


        //public async Task<Customer> GetCustomerAsync(string email)
        //{
        
        //}


    //    public async Task<CustomerEntity> GetCustomerEntityByIdAsync(Guid id)
    //    {
         
    //    }


    //    public async Task UpdateCustomerAsync(CustomerEntity customerEntity)
    //    {
        
    //    }


    //    public async Task DeleteCustomerAsync(string email)
    //    {
         
    //    }

    //    public async Task<AddressEntity> GetAddressEntityByIdAsync(int id)
    //    {
        
    //    }
    }
}
